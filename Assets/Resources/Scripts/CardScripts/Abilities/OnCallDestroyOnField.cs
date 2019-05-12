using UnityEngine;
using System.Collections;

//"When you put this creature into the battle zone, destroy all creatures that have [property]" ability
//TODO: possible change: add int how many to destroy for abilities that doesnt destroy all on field
public class OnCallDestroyOnField : IAbility
{
    public delegate bool ComparingDelegate(Card card);
    public ComparingDelegate comparingFunction;

    public OnCallDestroyOnField(ComparingDelegate function)
    {
        comparingFunction = function;
    }

    public void AddScriptToQueue()
    {
        EventQueue.Enqueue(OnCallCoroutine);
    }

    public void SubscribeToEvent()
    {
        EventManager.OnCallEvent += AddScriptToQueue;
    }

    public void UnsubscribeToEvent()
    {
        EventManager.OnCallEvent -= AddScriptToQueue;
    }

    public IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        int cnt = currentPlayer.GetFieldCount();
        for(int i = 0; i < cnt; i++)
        {
            var card = currentPlayer.GetFieldAt(i);
            if (comparingFunction.Invoke(card))
            {
                currentPlayer.RemoveFieldAddGraveyard(card);
            }
        }
        cnt = otherPlayer.GetFieldCount();
        for (int i = 0; i < cnt; i++)
        {
            var card = otherPlayer.GetFieldAt(i);
            if (comparingFunction.Invoke(card))
            {
                otherPlayer.RemoveFieldAddGraveyard(card);
            }
        }
        yield return null;
    }
}
