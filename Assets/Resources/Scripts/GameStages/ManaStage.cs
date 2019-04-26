using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaStage : GameStage
{
    public int selectedCardToManaID {get; set;}

    public ManaStage(StageFSM stageFSM) : base(stageFSM) { }

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
            //move card
            selectedCard.Dehighlight();
            var card = currentPlayer.GetCardFromList(ref currentPlayer.hand, selectedCardID);
            currentPlayer.AddCardToList(ref currentPlayer.manaZone.cards, card);
            //set positions
            currentPlayer.SetHandPositions();
            currentPlayer.manaZone.SetPositions(currentPlayer.isPlayerOne);
            //set for next stage
            selectedCardToManaID = currentPlayer.manaZone.cards.Count - 1;
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
