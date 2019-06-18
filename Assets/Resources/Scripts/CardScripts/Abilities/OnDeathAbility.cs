using UnityEngine;
using System.Collections;

public class OnDeathAbility : Ability
{
    protected Card ownerCard;

    public OnDeathAbility(Card card)
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

    public virtual IEnumerator OnDeathCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        yield break;
    }
}
