using UnityEngine;
using System.Collections;

public class ShieldTrigger : Ability
{

    private Card ownerCard { get; set; }

    public ShieldTrigger(Card owner)
    {
        ownerCard = owner;
    }

    public override void OnShieldDestroyed()
    {
        SubscribeToEvent();
    }

    public override void OnAfterShieldDestroyed()
    {
        UnsubscribeToEvent();
    }

    public override void SubscribeToEvent()
    {
        EventManager.OnShieldDestroyedEvent += AddScriptToQueue;
    }

    public override void UnsubscribeToEvent()
    {
        EventManager.OnShieldDestroyedEvent -= AddScriptToQueue;
    }

    public override void AddScriptToQueue()
    {
        EventQueue.Enqueue(ShieldTriggerCoroutine);
    }

    public IEnumerator ShieldTriggerCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        while (true)
        {
            if (inputController.isEnterPressed)
            {
                otherPlayer.RemoveHandAddField(ownerCard);
                break;
            }
            if (inputController.isBackspacePressed)
            {
                break;
            }
            yield return null;
        }
        QueueControl.SignalCoroutineEnd();
    }

}
