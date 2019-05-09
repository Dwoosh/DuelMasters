using UnityEngine;
using System.Collections;

public class QueueControl : MonoBehaviour
{
    private static bool coroutineRunning { get; set; }

    public PlayerScript currentPlayer { get; set; }
    public PlayerScript otherPlayer { get; set; }

    public PlayerScript playerOne;
    public PlayerScript playerTwo;
    public InputController inputController;
    public Battlefield battlefield;
    public EventManager eventManager;

    void Start()
    {
        coroutineRunning = false;
        currentPlayer = playerOne;
        otherPlayer = playerTwo;
    }

    public bool CheckQueue()
    {
        if (coroutineRunning) { return true; }
        else if (EventQueue.IsNotEmpty())
        {
            EventQueue.EventCoroutine eventCoroutine = EventQueue.Dequeue();
            coroutineRunning = true;
            StartCoroutine(eventCoroutine(currentPlayer, otherPlayer, inputController, battlefield, eventManager));
            return true;
        }
        return false;
    }

    public static void SignalCoroutineEnd()
    {
        coroutineRunning = false;
    }

    public void SwitchPlayers()
    {
        if (currentPlayer.Equals(playerOne))
        {
            currentPlayer = playerTwo;
            otherPlayer = playerOne;
        }
        else
        {
            currentPlayer = playerOne;
            otherPlayer = playerTwo;
        }
    }
}
