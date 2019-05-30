using UnityEngine;
using System.Collections;

//"When you put this creature into the battle zone, [action on] all creatures that have [property]" ability
//TODO: possible change: add int how many to destroy for abilities that doesnt destroy all on field
public class OnCallActionAll : OnCallAbility
{
    private System.Func<Card, bool> comparingFunction { get; set; }
    private System.Action<Card, PlayerScript> actionFunction { get; set; }
    private bool onlyChooseOpponent { get; set; }

    public OnCallActionAll(System.Func<Card,bool> comparator, System.Action<Card, PlayerScript> action, bool opponentOnly)
    {
        comparingFunction = comparator;
        actionFunction = action;
        onlyChooseOpponent = opponentOnly;
    }
    
    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        int cnt = otherPlayer.GetFieldCount();
        for (int i = 0; i < cnt; i++)
        {
            var card = otherPlayer.GetFieldAt(i);
            if (comparingFunction.Invoke(card))
            {
                actionFunction(card, otherPlayer);
            }
        }
        if (!onlyChooseOpponent)
        {
            cnt = currentPlayer.GetFieldCount();
            for (int i = 0; i < cnt; i++)
            {
                var card = currentPlayer.GetFieldAt(i);
                if (comparingFunction.Invoke(card))
                {
                    actionFunction(card, currentPlayer);
                }
            }
        }
        yield return null;
    }
}
