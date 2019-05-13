using UnityEngine;
using System.Collections;

//"When this creature would be destroyed, put it into your hand instead" ability
public class OnDeathReturnToHand : Ability
{
    private Card ownerCard;

    public OnDeathReturnToHand(Card card)
    {
        ownerCard = card;
    }

    public override void OnDeath()
    {
        SubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        UnsubscribeToEvent();
    }

    public override void AddScriptToQueue()
    {
        EventQueue.Enqueue(OnDeathCoroutine);
    }

    public override void SubscribeToEvent()
    {
        EventManager.OnDeathEvent += AddScriptToQueue;
    }

    public override void UnsubscribeToEvent()
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
