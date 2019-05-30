using UnityEngine;
using System.Collections;

public class OnCallDiscardRandom : OnCallAbility
{

    private int toDiscard { get; set; }

    public OnCallDiscardRandom(int count)
    {
        toDiscard = count;
    }

    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        int count = Mathf.Min(toDiscard, otherPlayer.GetHandCount());
        while(count != 0)
        {
            otherPlayer.RemoveHandAddGraveyard(Random.Range(0, count));
        }
        QueueControl.SignalCoroutineEnd();
        return null;
    }
}
