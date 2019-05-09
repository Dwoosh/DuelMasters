using UnityEngine;
using System.Collections;

public class FightTargetShieldStage : GameStage
{
    public Battlefield battlefield { get; set; }

    public new string controlsText = "Controls:\nLeft/Right Arrow to choose card\n" +
                                    "Up/Down Arrow to switch between shields and field\n" +
                                    "Enter to select card as target\nShift to skip to next stage";

    public FightTargetShieldStage(StageFSM stageFSM) : base(stageFSM)
    {
        battlefield = stageFSM.battlefield;
    }

    public override GameStage ManageStage()
    {
        //TODO: make targetable player object

        if (!otherPlayer.shieldZone.IsEmpty())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == otherPlayer.shieldZone.shields.Count ? selectedCardID - 1 : selectedCardID;
            selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
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
        if (inputController.isDownArrowPressed)
        {
            return OnDownArrowPress();
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
            selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
            selectedCard.Highlight();
        }
    }

    public override void OnRightArrowPress()
    {
        if (selectedCardID < otherPlayer.shieldZone.shields.Count - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
            selectedCard.Highlight();
        }
    }

    public override GameStage OnDownArrowPress()
    {
        if (IsCardSelected()){selectedCard.Dehighlight();}
        return StageFSM.fightTargetFieldStage;
    }

    //TODO: abilities..., double breaker, possible return this stage again
    public override GameStage OnEnterPress()
    {
        if (IsCardSelected())
        {
            selectedCard.Dehighlight();
            StageFSM.fightChooseStage.selectedCardToFight.Dehighlight();
            
            eventManager.CallOnShieldAttackEvent();

            var card = otherPlayer.shieldZone.RemoveShield(selectedCardID);
            otherPlayer.AddCardToList(ref otherPlayer.hand, card);
            otherPlayer.SetHandPositions();
            otherPlayer.shieldZone.SetPositions(otherPlayer.isPlayerOne);
        }
        return StageFSM.fightChooseStage;
    }

    public override GameStage OnBackspacePress()
    {
        if (IsCardSelected()) { selectedCard.Dehighlight(); }
        return StageFSM.fightChooseStage;
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("fight target shield stage");
        selectedCardID = -1;
        selectedCard = null;
    }

}
