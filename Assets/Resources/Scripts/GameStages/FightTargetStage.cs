using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTargetStage : GameStage
{
    public Battlefield battlefield { get; set; }
    public bool isShieldTargeted { get; set; }
    public Card selectedCardAsTarget { get; set; }

    public FightTargetStage(StageFSM stageFSM) : base(stageFSM) {
        battlefield = stageFSM.battlefield;
    }

    public override GameStage ManageStage()
    {
        //TODO: make targetable player object

        if (battlefield.IsOtherPlayerFieldFull())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == battlefield.otherPlayerCards.Count ? selectedCardID - 1 : selectedCardID;
            selectedCard = battlefield.otherPlayerCards[selectedCardID];
            selectedCard.Highlight();
        }
        else if (!otherPlayer.shieldZone.IsEmpty())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == otherPlayer.shieldZone.shields.Count ? selectedCardID - 1 : selectedCardID;
            selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
            selectedCard.Highlight();
            isShieldTargeted = true;
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
            OnUpArrowPress();
        }
        if (inputController.isDownArrowPressed)
        {
            OnDownArrowPress();
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
            if (isShieldTargeted) { selectedCard = otherPlayer.shieldZone.shields[selectedCardID]; }
            else { selectedCard = battlefield.otherPlayerCards[selectedCardID]; }
            selectedCard.Highlight();
        }
    }

    public override void OnRightArrowPress()
    {
        if (isShieldTargeted && selectedCardID < otherPlayer.shieldZone.shields.Count - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
            selectedCard.Highlight();
        }
        else if (!isShieldTargeted && selectedCardID < battlefield.otherPlayerCards.Count - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = battlefield.otherPlayerCards[selectedCardID];
            selectedCard.Highlight();
        }
    }

    public override void OnUpArrowPress()
    {
        if (!isShieldTargeted && !otherPlayer.shieldZone.IsEmpty())
        {
            selectedCard.Dehighlight();
            selectedCardID = 0;
            selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
            selectedCard.Highlight();
            isShieldTargeted = true;
        }
    }

    public override void OnDownArrowPress()
    {
        if (isShieldTargeted && battlefield.IsOtherPlayerFieldFull())
        {
            selectedCard.Dehighlight();
            selectedCardID = 0;
            selectedCard = battlefield.otherPlayerCards[selectedCardID];
            selectedCard.Highlight();
            isShieldTargeted = false;
        }
    }

    public override GameStage OnEnterPress()
    {
        if (IsCardSelected())
        {
            if (isShieldTargeted)
            {
                selectedCard.Dehighlight();
                StageFSM.fightChooseStage.selectedCardToFight.Dehighlight();
                var card = otherPlayer.shieldZone.RemoveShield(selectedCardID);
                otherPlayer.AddCardToList(ref otherPlayer.hand, card);
                otherPlayer.SetHandPositions();
                otherPlayer.shieldZone.SetPositions(otherPlayer.isPlayerOne);
            }
            else
            {
                selectedCardAsTarget = battlefield.otherPlayerCards[selectedCardID];
                return StageFSM.battleStage;
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
        Debug.Log("fight target stage");
        selectedCardID = -1;
        selectedCard = null;
        isShieldTargeted = false;
        selectedCardAsTarget = null;
    }

}
