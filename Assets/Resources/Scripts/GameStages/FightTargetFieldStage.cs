using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTargetFieldStage : GameStage
{
    public Battlefield battlefield { get; set; }
    public Card selectedCardAsTarget { get; set; }

    public override string controlsText { get; set; }

    public FightTargetFieldStage(StageFSM stageFSM) : base(stageFSM) {
        battlefield = stageFSM.battlefield;
        controlsText = "Controls:\nLeft/Right Arrow to choose card\n" +
                                    "Up/Down Arrow to switch between shields and field\n" +
                                    "Enter to select card as target\nShift to skip to next stage";
    }

    public override GameStage ManageStage()
    {
        
        if (battlefield.IsOtherPlayerFieldNotEmpty())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == battlefield.otherPlayerCards.Count ? selectedCardID - 1 : selectedCardID;
            selectedCard = otherPlayer.GetFieldAt(selectedCardID);
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
        if (inputController.isUpArrowPressed)
        {
            return OnUpArrowPress();
        }
        if (inputController.isEnterPressed)
        {
            return OnEnterPress();
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
            selectedCard = otherPlayer.GetFieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    public override void OnRightArrowPress()
    {
        if (selectedCardID < otherPlayer.GetFieldCount() - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = otherPlayer.GetFieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    public override GameStage OnUpArrowPress()
    {
        if (IsCardSelected()) { selectedCard.Dehighlight(); }
        return StageFSM.fightTargetShieldStage;
    }

    public override GameStage OnEnterPress()
    {
        if (IsCardSelected() && !StageFSM.fightChooseStage.selectedCardToFight.cantAttack)
        {
            selectedCardAsTarget = otherPlayer.GetFieldAt(selectedCardID);
            if ((selectedCardAsTarget.isTapped || selectedCardAsTarget.vulnerableUntapped)
                ^ StageFSM.fightChooseStage.selectedCardToFight.canAttackUntapped)
            {
                return StageFSM.blockerStage;
            }
        }
        return null;
    }

    public override GameStage OnBackspacePress()
    {
        if (IsCardSelected()) { selectedCard.Dehighlight(); }
        return StageFSM.fightChooseStage;
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("fight target field stage");
        selectedCardID = -1;
        selectedCard = null;
        selectedCardAsTarget = null;
    }

}
