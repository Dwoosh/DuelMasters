using UnityEngine;
using System.Collections;

//"When you put this creature into the battle zone, choose creatures and return them to their owners' hands" ability
//TODO: possible change: same ability that works only for opponent?
public class OnCallReturnToHand : Ability
{
    private int amountToReturn;

    private int selectedCardID = -1;
    private Card selectedCard = null;
    private bool isOtherPlayerFieldSelected = true;

    public OnCallReturnToHand(int amount)
    {
        amountToReturn = amount;
    }

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

    public IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        int toReturn = amountToReturn;
        while (toReturn > 0)
        {
            //select first card on start
            if (selectedCardID == -1 && otherPlayer.IsFieldNotEmpty())
            {
                SelectOtherPlayerCard(otherPlayer);
            }
            else if (selectedCardID == -1 && currentPlayer.IsFieldNotEmpty())
            {
                SelectCurrentPlayerCard(currentPlayer);
            }
            //handle switching between battlefield sides
            if (inputController.isDownArrowPressed)
            {
                if (isOtherPlayerFieldSelected && currentPlayer.IsFieldNotEmpty())
                {
                    SelectCurrentPlayerCard(currentPlayer);
                }
            }
            if (inputController.isUpArrowPressed)
            {
                if (!isOtherPlayerFieldSelected && otherPlayer.IsFieldNotEmpty())
                {
                    SelectOtherPlayerCard(otherPlayer);
                }
            }
            //handle switching between cards on field
            if (inputController.isLeftArrowPressed)
            {
                if (isOtherPlayerFieldSelected) { OnLeftArrowPress(otherPlayer); }
                else OnLeftArrowPress(currentPlayer);
            }
            if (inputController.isRightArrowPressed)
            {
                if (isOtherPlayerFieldSelected) { OnRightArrowPress(otherPlayer); }
                else OnRightArrowPress(currentPlayer);
            }
            //handle return to hand
            if (inputController.isEnterPressed)
            {
                if(selectedCard != null)
                {
                    selectedCard.Dehighlight();
                    if (isOtherPlayerFieldSelected)
                    {
                        otherPlayer.RemoveFieldAddHand(selectedCard);
                    }
                    else
                    {
                        currentPlayer.RemoveFieldAddHand(selectedCard);
                    }
                    toReturn -= 1;
                }
            }
            if (inputController.isBackspacePressed)
            {
                if(selectedCard != null) { selectedCard.Dehighlight(); }
                break;
            }
            yield return null;
        }
        QueueControl.SignalCoroutineEnd();
    }

    private void SelectOtherPlayerCard(PlayerScript otherPlayer)
    {
        selectedCardID = 0;   //select first card if there are any
        selectedCard = otherPlayer.GetFieldAt(selectedCardID);
        selectedCard.Highlight();
        isOtherPlayerFieldSelected = true;
    }

    private void SelectCurrentPlayerCard(PlayerScript currentPlayer)
    {
        selectedCardID = 0;   //select first card if there are any
        selectedCard = currentPlayer.GetFieldAt(selectedCardID);
        selectedCard.Highlight();
        isOtherPlayerFieldSelected = false;
    }

    private void OnLeftArrowPress(PlayerScript player)
    {
        if (selectedCardID > 0)
        {
            selectedCard.Dehighlight();
            selectedCardID -= 1;
            selectedCard = player.GetFieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    private void OnRightArrowPress(PlayerScript player)
    {
        if (selectedCardID < player.GetFieldCount() - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = player.GetFieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }
}
