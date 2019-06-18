using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//"When you put this creature into the battle zone, [action on] all creatures that have [property]" ability
//TODO: possible change: add int how many to destroy for abilities that doesnt destroy all on field
public class OnCallActionAll : OnCallAbility
{
    private System.Func<Card, bool> comparingFunction { get; set; }
    private System.Action<Card, PlayerScript> actionFunction { get; set; }
    private bool actOnOpponent { get; set; }
    private bool actOnCurrent { get; set; }

    public List<Card> chosenCards { get; set; }

    public OnCallActionAll(System.Func<Card,bool> comparator, System.Action<Card, PlayerScript> action, bool you, bool opponent)
    {
        comparingFunction = comparator;
        actionFunction = action;
        actOnOpponent = opponent;
        actOnCurrent = you;
        chosenCards = new List<Card>();
    }
    
    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        int cnt = otherPlayer.GetFieldCount();
        if (actOnOpponent)
        {
            for (int i = 0; i < cnt; i++)
            {
                var card = otherPlayer.GetFieldAt(i);
                if (comparingFunction.Invoke(card))
                {
                    actionFunction(card, otherPlayer);
                    chosenCards.Add(card);
                }
            }
        }
        if (actOnCurrent)
        {
            cnt = currentPlayer.GetFieldCount();
            for (int i = 0; i < cnt; i++)
            {
                var card = currentPlayer.GetFieldAt(i);
                if (comparingFunction.Invoke(card))
                {
                    actionFunction(card, currentPlayer);
                    chosenCards.Add(card);
                }
            }
        }
        yield return null;
    }
}
