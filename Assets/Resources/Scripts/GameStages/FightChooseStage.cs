using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightChooseStage : GameStage
{
    public Battlefield battlefield { get; set; }
    public int selectedCardToFightID { get; set; }
    public Card selectedCardToFight { get; set; }

    public FightChooseStage(StageFSM stageFSM) : base(stageFSM) {
        battlefield = stageFSM.battlefield;
    }

    public override GameStage ManageStage()
    {
        if (battlefield.IsCurrentPlayerFieldFull())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == battlefield.currentPlayerCards.Count ? selectedCardID - 1 : selectedCardID;
            selectedCard = battlefield.currentPlayerCards[selectedCardID];
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
            selectedCard = battlefield.currentPlayerCards[selectedCardID];
            selectedCard.Highlight();
        }
    }

    public override void OnRightArrowPress()
    {
        if (selectedCardID < battlefield.currentPlayerCards.Count - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = battlefield.currentPlayerCards[selectedCardID];
            selectedCard.Highlight();
        }
    }

    public override GameStage OnEnterPress()
    {
        if (IsCardSelected() && !selectedCard.isTapped)
        {
            selectedCardToFightID = selectedCardID;
            selectedCardToFight = battlefield.currentPlayerCards[selectedCardToFightID];
            selectedCardToFight.Tap();
            return StageFSM.fightTargetStage;
        }
        return null;
    }

    public override GameStage OnShiftPress()
    {
        if (IsCardSelected()) { selectedCard.Dehighlight(); }
        return StageFSM.endStage;
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("fight choose stage");
        selectedCardID = -1;
        selectedCard = null;
        selectedCardToFightID = -1;
        selectedCardToFight = null;
    }

}
