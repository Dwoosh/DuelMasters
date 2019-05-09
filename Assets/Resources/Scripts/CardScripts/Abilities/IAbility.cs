using UnityEngine;
using System.Collections;

public interface IAbility
{
    void SubscribeToEvent();

    void UnsubscribeToEvent();

    void AddScriptToQueue();
}
