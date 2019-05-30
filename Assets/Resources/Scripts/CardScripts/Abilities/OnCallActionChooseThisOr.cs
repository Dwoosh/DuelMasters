using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnCallActionChooseThisOr : OnCallAbility
{
    private int actionCount { get; set; }
    private System.Action<Card, PlayerScript> playerAction { get; set; }
    private Card ownerCard { get; set; }

    private int selectedCardID = -1;
    private Card selectedCard = null;

    public List<Card> chosenCards { get; set; }

    public OnCallActionChooseThisOr(Card owner, int count, System.Action<Card, PlayerScript> action)
    {
        ownerCard = owner;
        actionCount = count;
        playerAction = action;
    }

    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        if (currentPlayer.GetHandCount() - 1 < actionCount)
        {
            playerAction(ownerCard, currentPlayer);
        }
        else
        {
            int count = actionCount;
            while (count > 0)
            {
                selectedCardID = 0;   //select first card if there are any
                selectedCard = currentPlayer.GetFieldAt(selectedCardID);
                selectedCard.Highlight();
                //handle switching between cards on field
                if (inputController.isLeftArrowPressed)
                {
                    if (selectedCardID > 0)
                    {
                        selectedCard.Dehighlight();
                        selectedCardID -= 1;
                        selectedCard = currentPlayer.GetFieldAt(selectedCardID);
                        selectedCard.Highlight();
                    }
                }
                if (inputController.isRightArrowPressed)
                {
                    if (selectedCardID < currentPlayer.GetFieldCount() - 1)
                    {
                        selectedCard.Dehighlight();
                        selectedCardID += 1;
                        selectedCard = currentPlayer.GetFieldAt(selectedCardID);
                        selectedCard.Highlight();
                    }
                }
                //handle action on enter
                if (inputController.isEnterPressed)
                {
                    if (selectedCard != ownerCard)
                    {
                        selectedCard.Dehighlight();
                        chosenCards.Add(selectedCard);
                        playerAction(selectedCard, currentPlayer);
                        count -= 1;
                    }
                }
                yield return null;
            }
        }
        QueueControl.SignalCoroutineEnd();
    }
    
}
