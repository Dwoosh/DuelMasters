using UnityEngine;
using System.Collections;

//"At the end of each turn, you can untap this creature" ability
public class EndTurnUntap : IAbility
{
    private Card owner;

    public EndTurnUntap(Card card)
    {
        owner = card;
    }

    public void AddScriptToQueue()
    {
        EventQueue.Enqueue(EndTurnUntapCoroutine);
    }

    public void SubscribeToEvent()
    {
        EventManager.OnEndTurnEvent += AddScriptToQueue;
    }

    public void UnsubscribeToEvent()
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
