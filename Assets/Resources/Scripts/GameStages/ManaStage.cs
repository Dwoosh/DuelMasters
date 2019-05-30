using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaStage : GameStage
{
    public int selectedCardToManaID {get; set;}

    public override string controlsText { get; set; }

    public override string infoText { get; set; }

    public ManaStage(StageFSM stageFSM) : base(stageFSM) {
        controlsText = "Controls:\nLeft/Right Arrow to choose card\n" +
                       "Enter to select card to put to mana\nShift to skip to next stage";
        infoText = string.Empty;
    }

    public override GameStage ManageStage()
    {
        UpdateInfoText();
        if (currentPlayer.hand.Count > 0)
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == currentPlayer.hand.Count ? selectedCardID - 1 : selectedCardID;  //select last card if cards amount changed
            selectedCard = currentPlayer.GetHandAt(selectedCardID);
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
        return null;
    }

    public override void OnLeftArrowPress()
    {
        if (selectedCardID > 0)
        {
            selectedCard.Dehighlight();
            selectedCardID -= 1;
            selectedCard = currentPlayer.GetHandAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    public override void OnRightArrowPress()
    {
        if (selectedCardID < currentPlayer.GetHandCount() - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = currentPlayer.GetHandAt(selectedCardID);
            selectedCard.Highlight();
        }
    }
    
    public override GameStage OnEnterPress()
    {
        if (IsCardSelected())
        {
            //move card
            selectedCard.Dehighlight();
            currentPlayer.RemoveHandAddMana(selectedCardID);
            //set for next stage
            selectedCardToManaID = currentPlayer.GetManaCount() - 1;
            return StageFSM.callChooseStage;
        }
        return null;
    }

    public override GameStage OnShiftPress()
    {
        if (IsCardSelected()) {
            selectedCard.Dehighlight();
            return StageFSM.callChooseStage;
        }
        return null;
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("mana stage");
        selectedCardToManaID = -1;
        selectedCardID = -1;
        selectedCard = null;
    }

}
