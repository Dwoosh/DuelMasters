using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCallChooseStage : GameStage
{
    public int selectedCardToCallID { get; set; }
    public Card selectedCardToCall { get; set; }

    public new string controlsText = "Controls:\nLeft/Right Arrow to choose card\n" +
                                    "Enter to select card to summon\nShift to skip to next stage\n" +
                                    "Backspace to go back to previous stage";

    public CardCallChooseStage(StageFSM stageFSM) : base(stageFSM) { }

    public override GameStage ManageStage()
    {
        if (currentPlayer.hand.Count > 0)
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == currentPlayer.hand.Count ? selectedCardID - 1 : selectedCardID;  //select last card if cards amount changed
            selectedCard = currentPlayer.hand[selectedCardID];
            selectedCard.Highlight();
        }
        if (inputController.isLeftArrowPressed)
        {
            OnLeftArrowPress();
        }
        if (inputController.isRightArrowPressed)
        {
            OnRightArrowPress();
        }
        if (inputController.isEnterPressed)
        {
            return OnEnterPress();
        }
        if (inputController.isShiftPressed)
        {
            return OnShiftPress();
        }
        if (inputController.isBackspacePressed)
        {
            return OnBackspacePress();
        }
        return null;
    }

    public override void OnLeftArrowPress()
    {
        if (selectedCardID > 0)
        {
            selectedCard.Dehighlight();
            selectedCardID -= 1;
            selectedCard = currentPlayer.hand[selectedCardID];
            selectedCard.Highlight();
        }
    }

    public override void OnRightArrowPress()
    {
        if (selectedCardID < currentPlayer.hand.Count - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = currentPlayer.hand[selectedCardID];
            selectedCard.Highlight();
        }
    }

    public override GameStage OnEnterPress()
    {
        if (IsCardSelected())
        {
            //change "pointers" and go to pay stage
            selectedCardToCallID = selectedCardID;
            selectedCardToCall = currentPlayer.hand[selectedCardToCallID];
            return StageFSM.callPayStage;
        }
        return null;
    }

    public override GameStage OnShiftPress()
    {
        if (IsCardSelected()) {
            selectedCard.Dehighlight();
            return StageFSM.fightChooseStage;
        }
        return null;
    }

    public override GameStage OnBackspacePress()
    {
        //move card back to hand
        if (IsCardSelected()) { selectedCard.Dehighlight(); }
        if (StageFSM.manaStage.selectedCardToManaID != -1)
        {
            var card = currentPlayer.GetCardFromList(ref currentPlayer.manaZone.cards, StageFSM.manaStage.selectedCardToManaID);
            currentPlayer.AddCardToList(ref currentPlayer.hand, card);
        }
        //set positions
        currentPlayer.SetHandPositions();
        currentPlayer.manaZone.SetPositions(currentPlayer.isPlayerOne);
        return StageFSM.manaStage;
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("card call choose stage");
        selectedCardToCallID = -1;
        selectedCardToCall = null;
        selectedCardID = -1;
        selectedCard = null;
    }
}
