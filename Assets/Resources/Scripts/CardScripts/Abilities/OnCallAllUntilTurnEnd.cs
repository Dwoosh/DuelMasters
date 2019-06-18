using UnityEngine;
using System.Collections;

public class OnCallAllUntilTurnEnd : OnCallActionAll
{
    private System.Action<Card> removeAbilities { get; set; }

    public OnCallAllUntilTurnEnd(System.Func<Card, bool> comparator, System.Action<Card, PlayerScript> action, System.Action<Card> toRemove, 
        bool you, bool opponent) : base(comparator, action, you, opponent) {

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
                foreach (Card card in chosenCards)
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
