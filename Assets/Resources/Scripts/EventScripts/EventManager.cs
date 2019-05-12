using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void EventDelegate();
    
    public static event EventDelegate OnShieldAttackEvent;
    
    public static event EventDelegate OnEndTurnEvent;
    
    public static event EventDelegate OnCallEvent;

    public static event EventDelegate OnFieldAttackEvent;

    public static event EventDelegate OnDeathEvent;

    public static event EventDelegate OnBlockerEvent;

    public void CallOnShieldAttackEvent()
    {
        OnShieldAttackEvent?.Invoke();
    }

    public void CallOnEndTurnEvent()
    {
        OnEndTurnEvent?.Invoke();
    }

    public void CallOnCallEvent()
    {
        OnCallEvent?.Invoke();
    }

    public void CallOnFieldEvent()
    {
        OnFieldAttackEvent?.Invoke();
    }

    public void CallOnDeathEvent()
    {
        OnDeathEvent?.Invoke();
    }

    public void CallOnBlockerEvent()
    {
        OnBlockerEvent?.Invoke();
    }

}
