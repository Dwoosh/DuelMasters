using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//"When you put this creature into the battle zone, choose creatures..." ability
//TODO: possible change: add requirement to choose x cards, instead of possibility only
//      possible softlock when theres forcedChoice and not enough cards to choose
//TODO: get minimum of actionCount and field
//TODO: who is choosing?
public class OnCallActionChoose : OnCallAbility
{
    private int actionCount { get; set; }
    private System.Action<Card> cardAction { get; set; }
    private System.Action<Card, PlayerScript> playerAction { get; set; }
    private System.Func<Card, bool> comparingFunction { get; set; }
    private bool onlyChooseOpponent { get; set; }
    private bool onlyChooseYours { get; set; }
    private bool forceChoice { get; set; }

    private int selectedCardID = -1;
    private Card selectedCard = null;
    private bool isOtherPlayerFieldSelected = true;

    public List<Card> chosenCards { get; set; }

    public OnCallActionChoose(System.Action<Card> actionFunc, int amount, bool opponentOnly, bool yoursOnly, bool forcedChoice)
    {
        cardAction = actionFunc;
        playerAction = null;
        actionCount = amount;
        onlyChooseOpponent = opponentOnly;
        onlyChooseYours = yoursOnly;
        chosenCards = new List<Card>(actionCount);
        forceChoice = forcedChoice;
        comparingFunction = x => { return true; };
    }

    public OnCallActionChoose(System.Action<Card, PlayerScript> actionFunc, int amount, bool opponentOnly, bool yoursonly, bool forcedChoice)
    {
        playerAction = actionFunc;
        cardAction = null;
        actionCount = amount;
        onlyChooseOpponent = opponentOnly;
        onlyChooseYours = yoursonly;
        chosenCards = new List<Card>(actionCount);
        forceChoice = forcedChoice;
        comparingFunction = x => { return true; };
    }

    public OnCallActionChoose(System.Action<Card, PlayerScript> actionFunc, int amount, 
        bool opponentOnly, bool yoursonly, bool forcedChoice, System.Func<Card, bool> comparator)
    {
        playerAction = actionFunc;
        cardAction = null;
        actionCount = amount;
        onlyChooseOpponent = opponentOnly;
        onlyChooseYours = yoursonly;
        chosenCards = new List<Card>(actionCount);
        forceChoice = forcedChoice;
        comparingFunction = comparator;
    }

    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        int count = actionCount;
        while (count > 0)
        {
            //select first card on start
            if (selectedCardID == -1 && otherPlayer.IsFieldNotEmpty() && !onlyChooseYours)
            {
                SelectOtherPlayerCard(otherPlayer);
            }
            else if (selectedCardID == -1 && currentPlayer.IsFieldNotEmpty() && !onlyChooseOpponent)
            {
                SelectCurrentPlayerCard(currentPlayer);
            }
            //handle switching between battlefield sides
            if (inputController.isDownArrowPressed)
            {
                if (isOtherPlayerFieldSelected && currentPlayer.IsFieldNotEmpty() && !onlyChooseOpponent)
                {
                    SelectCurrentPlayerCard(currentPlayer);
                }
            }
            if (inputController.isUpArrowPressed)
            {
                if (!isOtherPlayerFieldSelected && otherPlayer.IsFieldNotEmpty() && !onlyChooseYours)
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
            //handle action on enter
            if (inputController.isEnterPressed)
            {
                if(selectedCard != null)
                {
                    if (comparingFunction.Invoke(selectedCard))
                    {
                        selectedCard.Dehighlight();
                        chosenCards.Add(selectedCard);
                        if (cardAction != null) { cardAction(selectedCard); }
                        else
                        {
                            if (isOtherPlayerFieldSelected)
                            {
                                playerAction(selectedCard, otherPlayer);
                            }
                            else
                            {
                                playerAction(selectedCard, currentPlayer);
                            }
                        }
                        count -= 1;
                    }
                }
            }
            //dismiss action on backspace
            if (inputController.isBackspacePressed)
            {
                if (!forceChoice)
                {
                    chosenCards.Add(null);
                    count -= 1;
                }
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
