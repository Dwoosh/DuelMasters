using UnityEngine;
using System.Collections;

public abstract class Ability
{
    public virtual void SubscribeToEvent() { }
    public virtual void UnsubscribeToEvent() { }
    public virtual void AddScriptToQueue() { }

    public virtual void OnCall() { }
    public virtual void OnAfterCall() { }
    public virtual void OnShieldAttack() { }
    public virtual void OnAfterShieldAttack() { }
    public virtual void OnShieldDestroyed() { }
    public virtual void OnAfterShieldDestroyed() { }
    public virtual void OnDeath() { }
    public virtual void OnAfterDeath() { }

    public virtual void SubscribeToTurnEvents() { }
    public virtual void UnsubscribeToTurnEvents() { }
    public virtual void SubscribeToOddTurnEvents() { }
    public virtual void UnsubscribeToOddTurnEvents() { }
}
