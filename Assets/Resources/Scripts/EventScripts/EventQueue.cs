using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventQueue
{
    public delegate IEnumerator EventCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer, 
        InputController inputController);

    private static Queue<EventCoroutine> eventQueue = new Queue<EventCoroutine>();
    
    public static void Enqueue(EventCoroutine script)
    {
        eventQueue.Enqueue(script);
    }

    public static EventCoroutine Dequeue()
    {
        return eventQueue.Dequeue();
    }

    public static void Clear()
    {
        eventQueue.Clear();
    }

    public static bool IsNotEmpty()
    {
        return eventQueue.Count != 0;
    }

}
