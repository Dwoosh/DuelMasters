﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCallPayStage : GameStage
{

    public Battlefield battlefield { get; set; }

    public CardCallPayStage(StageFSM stageFSM) : base(stageFSM) {
        battlefield = stageFSM.battlefield;
    }

    public override GameStage ManageStage()
    {
        if (currentPlayer.manaZone.cards.Count > 0)
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            //selectedCardID = selectedCardID == currentPlayer.manaZone.cards.Count ? selectedCardID - 1 : selectedCardID;  //select last card if cards amount changed
            selectedCard = currentPlayer.manaZone.cards[selectedCardID];
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
            selectedCard = currentPlayer.manaZone.cards[selectedCardID];
            selectedCard.Highlight();
        }
    }

    public override void OnRightArrowPress()
    {
        if (selectedCardID < currentPlayer.manaZone.cards.Count - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = currentPlayer.manaZone.cards[selectedCardID];
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
            currentPlayer.manaZone.FinalizeManaTap();
            var card = currentPlayer.GetCardFromList(ref currentPlayer.hand, StageFSM.callChooseStage.selectedCardToCallID);
            battlefield.AddCardToBattlefield(card, currentPlayer.isPlayerOne);
            //set positions
            currentPlayer.SetHandPositions();
            battlefield.SetPositions();
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
