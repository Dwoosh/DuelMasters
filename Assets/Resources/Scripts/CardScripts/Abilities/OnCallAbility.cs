using UnityEngine;
using System.Collections;

public abstract class OnCallAbility : Ability
{

    public override void OnCall()
    {
        SubscribeToEvent();
    }

    public override void OnAfterCall()
    {
        UnsubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        UnsubscribeToEvent();
    }

    public override void AddScriptToQueue()
    {
        EventQueue.Enqueue(OnCallCoroutine);
    }

    public override void SubscribeToEvent()
    {
        EventManager.OnCallEvent += AddScriptToQueue;
    }

    public override void UnsubscribeToEvent()
    {
        EventManager.OnCallEvent -= AddScriptToQueue;
    }

    public virtual IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        QueueControl.SignalCoroutineEnd();
        return null;
    }

}
