using UnityEngine;
using System.Collections;

//"At the end of each turn, you can untap this creature" ability
public class EndTurnUntap : Ability
{
    private Card ownerCard { get; set; }
    private bool untapAllCards { get; set; }

    public EndTurnUntap(Card card, bool untapAll)
    {
        ownerCard = card;
        untapAllCards = untapAll;
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
        ownerCard.Highlight();
        while (true)
        {
            if (inputController.isEnterPressed)
            {
                if (!untapAllCards)
                {
                    ownerCard.Untap();
                    ownerCard.Dehighlight();
                    break;
                }
                else
                {
                    ownerCard.Dehighlight();
                    ownerCard.owner.ActOnField(card => card.Untap());
                    break;
                }
            }
            if (inputController.isBackspacePressed)
            {
                ownerCard.Dehighlight();
                break;
            }
            yield return null;
        }
        QueueControl.SignalCoroutineEnd();
    }

}
