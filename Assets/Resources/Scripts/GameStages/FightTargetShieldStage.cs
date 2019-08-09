using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class FightTargetShieldStage : GameStage
{
    public Battlefield battlefield { get; set; }
    public Card selectedCardAsTarget { get; set; }

    public override string controlsText { get; set; }

    public FightTargetShieldStage(StageFSM stageFSM) : base(stageFSM)
    {
        battlefield = stageFSM.battlefield;
        controlsText = "Controls:\nLeft/Right Arrow to choose card\n" +
                                    "Up/Down Arrow to switch between shields and field\n" +
                                    "Enter to select card as target\nShift to skip to next stage";
    }

    public override GameStage ManageStage()
    {
        //TODO: make targetable player object

        if (!otherPlayer.shieldZone.IsEmpty())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == otherPlayer.shieldZone.shields.Count ? selectedCardID - 1 : selectedCardID;
            selectedCard = otherPlayer.GetShieldAt(selectedCardID);
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
            selectedCard = otherPlayer.GetShieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    public override void OnRightArrowPress()
    {
        if (selectedCardID < otherPlayer.GetShieldCount() - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = otherPlayer.GetShieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    public override GameStage OnDownArrowPress()
    {
        if (IsCardSelected()){selectedCard.Dehighlight();}
        return StageFSM.fightTargetFieldStage;
    }
    
    public override GameStage OnEnterPress()
    {
        if (IsCardSelected() && !StageFSM.fightChooseStage.selectedCardToFight.HasSimpleAbility(SimpleAbility.CantAttackPlayers)
            && !StageFSM.fightChooseStage.selectedCardToFight.HasSimpleAbility(SimpleAbility.CantAttack))
        {
            selectedCard.Dehighlight();
            selectedCardAsTarget = selectedCard;
            StageFSM.fightChooseStage.selectedCardToFight.Dehighlight();
            return StageFSM.blockerStage;
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
        Debug.Log("fight target shield stage");
        selectedCardID = -1;
        selectedCard = null;
        selectedCardAsTarget = null;
    }

}
