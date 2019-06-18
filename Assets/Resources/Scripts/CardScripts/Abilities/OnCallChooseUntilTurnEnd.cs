using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//TODO: possible forced choice too?
public class OnCallChooseUntilTurnEnd : OnCallActionChoose
{
    
    private System.Action<Card> removeAbilities { get; set; }

    public OnCallChooseUntilTurnEnd(System.Action<Card> toGive, System.Action<Card> toRemove, int amount, bool yoursOnly, 
        bool opponentOnly) : base(toGive, amount, opponentOnly, yoursOnly, false)
    {
        removeAbilities = toRemove;
        StartCoroutine(RemovingCoroutine());
    }

    private IEnumerator RemovingCoroutine()
    {
        StageFSM stageFSM = GameStage.stageFSM;
        while (true)
        {
            if (stageFSM.currentGameStage == StageFSM.endStage) //undo at the end of the turn
            {
                foreach(Card card in chosenCards)
                {
                    removeAbilities(card);
                }
                break;
            }
            yield return null;
        }
        yield break;
    }
}
