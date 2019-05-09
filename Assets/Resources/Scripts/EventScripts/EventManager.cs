using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{

    public delegate void OnShieldAttack();
    public static event OnShieldAttack OnShieldAttackEvent;

    public void CallOnShieldAttackEvent()
    {
        OnShieldAttackEvent?.Invoke();
    }

}
