using UnityEngine;
using System.Collections;

//"At the end of each turn, you can untap this creature" ability
public class EndTurnUntap : Ability
{
    private Card owner;

    public EndTurnUntap(Card card)
    {
        owner = card;
    }

    public override void SubscribeToTurnEvents()
    {
        SubscribeToEvent();
    }

    public override void UnsubscribeToTurnEvents()
    {
        UnsubscribeToEvent();
    }

    public override void OnCall()
    {
        SubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        UnsubscribeToEvent();
    }

    public override void AddScriptToQueue()
    {
        EventQueue.Enqueue(EndTurnUntapCoroutine);
    }

    public override void SubscribeToEvent()
    {
        EventManager.OnEndTurnEvent += AddScriptToQueue;
    }

    public override void UnsubscribeToEvent()
    {
        EventManager.OnEndTurnEvent -= AddScriptToQueue;
    }

    public IEnumerator EndTurnUntapCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        owner.Highlight();
        while (true)
        {
            if (inputController.isEnterPressed)
            {
                owner.Untap();
                owner.Dehighlight();
                break;
            }
            if (inputController.isBackspacePressed)
            {
                owner.Dehighlight();
                break;
            }
            yield return null;
        }
        QueueControl.SignalCoroutineEnd();
    }

}
