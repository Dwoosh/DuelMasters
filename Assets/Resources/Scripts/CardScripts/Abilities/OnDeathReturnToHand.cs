using UnityEngine;
using System.Collections;

//"When this creature would be destroyed, put it into your hand instead" ability
public class OnDeathReturnToHand : IAbility
{
    private Card ownerCard;

    public OnDeathReturnToHand(Card card)
    {
        ownerCard = card;
    }

    public void AddScriptToQueue()
    {
        EventQueue.Enqueue(OnDeathCoroutine);
    }

    public void SubscribeToEvent()
    {
        EventManager.OnDeathEvent += AddScriptToQueue;
    }

    public void UnsubscribeToEvent()
    {
        EventManager.OnDeathEvent -= AddScriptToQueue;
    }

    public IEnumerator OnDeathCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        ownerCard.owner.RemoveGraveyardAddHand(ownerCard);
        yield return null;
    }
}
