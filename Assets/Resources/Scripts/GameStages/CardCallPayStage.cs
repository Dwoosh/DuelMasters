using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCallPayStage : GameStage
{

    public Battlefield battlefield { get; set; }

    public override string controlsText { get; set; }

    public CardCallPayStage(StageFSM stageFSM) : base(stageFSM) {
        battlefield = stageFSM.battlefield;
        controlsText = "Controls:\nLeft/Right Arrow to choose card\n" +
                                    "Enter to tap card\nShift to summon\n" +
                                    "Backspace to go back to previous stage";
    }

    public override GameStage ManageStage()
    {
        if (currentPlayer.GetManaCount() > 0)
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == currentPlayer.manaZone.cards.Count ? selectedCardID - 1 : selectedCardID;  //select last card if cards amount changed
            selectedCard = currentPlayer.GetManaAt(selectedCardID);
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
            selectedCard = currentPlayer.GetManaAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    public override void OnRightArrowPress()
    {
        if (selectedCardID < currentPlayer.GetManaCount() - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = currentPlayer.GetManaAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    public override GameStage OnEnterPress()
    {
        if (IsCardSelected() && !selectedCard.isTapped)
        {
            if (selectedCard.isManaTapped)
            {
                selectedCard.ManaUntap();
                StageFSM.callChooseStage.selectedCardToCall.costPaid -= 1;
            }
            else
            {
                selectedCard.ManaTap();
                StageFSM.callChooseStage.selectedCardToCall.costPaid += 1;
            }
        }
        return null;
    }

    public override GameStage OnShiftPress()
    {
        if (StageFSM.callChooseStage.selectedCardToCall.IsCostPaid())
        {
            //move card
            selectedCard.Dehighlight();
            currentPlayer.FinalizeManaTap();
            currentPlayer.RemoveHandAddField(StageFSM.callChooseStage.selectedCardToCallID);
            return StageFSM.callChooseStage;
        }
        return null;
    }

    public override GameStage OnBackspacePress()
    {
        if (StageFSM.callChooseStage.selectedCardToCall.costPaid == 0)
        {
            selectedCard.Dehighlight();
            return StageFSM.callChooseStage;
        }
        return null;
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("pay stage");
        selectedCardID = -1;
        selectedCard = null;
    }
}
