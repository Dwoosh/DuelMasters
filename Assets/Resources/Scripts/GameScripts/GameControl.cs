using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public enum TurnStage { Mana, CardCall_Choose, CardCall_Pay, Fight_Choose, Fight_Target, Battle, End }

    private PlayerScript currentPlayer;
    private PlayerScript otherPlayer;
    public TurnStage turnStage;

    public Battlefield battlefield;
    public GameObject gamecamera;
    public PlayerScript playerOne;
    public PlayerScript playerTwo;
    public InputController inputController;

    private Card selectedCard;
    private Card selectedCardToCall;
    public int selectedCardID;
    public int selectedCardToCallID;
    public int selectedCardToManaID;
    public int selectedCardToFightID;
    public bool isShieldTargeted;

    void Start()
    {
        currentPlayer = playerOne;
        otherPlayer = playerTwo;
        turnStage = TurnStage.Mana;
        selectedCardID = -1;
        selectedCardToCallID = -1;
        selectedCardToManaID = -1;
        selectedCardToFightID = -1;
        selectedCard = null;
        selectedCardToCall = null;
        isShieldTargeted = false;
    }

    void Update()
    {
        inputController.PollForInput();
        switch (turnStage)
        {
            case TurnStage.Mana:
                ManageManaStage();
                break;
            case TurnStage.CardCall_Choose:
                ManageCallChooseStage();
                break;
            case TurnStage.CardCall_Pay:
                ManageCallPayStage();
                break;
            case TurnStage.Fight_Choose:
                ManageFightChooseStage();
                break;
            case TurnStage.Fight_Target:
                ManageFightTargetStage();
                break;
            case TurnStage.Battle:
                ManageBattleStage();
                break;
            case TurnStage.End:
                ManageEndTurn();
                break;
        }
    }

    private void ResetRefs()
    {
        selectedCardID = -1;
        selectedCardToCallID = -1;
        selectedCardToManaID = -1;
        selectedCardToFightID = -1;
        selectedCard = null;
        selectedCardToCall = null;
        isShieldTargeted = false;
    }

    private void ManageManaStage()
    {
        Debug.Log("mana stage");
        if (currentPlayer.hand.Count > 0)
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            selectedCardID = selectedCardID == currentPlayer.hand.Count ? selectedCardID - 1 : selectedCardID;  //select last card if cards amount changed
            selectedCard = currentPlayer.hand[selectedCardID];
            selectedCard.Highlight();
        }
        if (inputController.isLeftArrowPressed)
        {
            if (selectedCardID > 0)
            {
                selectedCard.Dehighlight();
                selectedCardID -= 1;
                selectedCard = currentPlayer.hand[selectedCardID];
                selectedCard.Highlight();
            }
        }
        if (inputController.isRightArrowPressed)
        {
            if (selectedCardID < currentPlayer.hand.Count - 1)
            {
                selectedCard.Dehighlight();
                selectedCardID += 1;
                selectedCard = currentPlayer.hand[selectedCardID];
                selectedCard.Highlight();
            }
        }
        if (inputController.isEnterPressed)
        {
            if (selectedCardID != -1)
            {
                //move card
                selectedCard.Dehighlight();
                var card = currentPlayer.GetCardFromList(ref currentPlayer.hand, selectedCardID);
                currentPlayer.AddCardToList(ref currentPlayer.manaZone.cards, card);
                //set positions
                currentPlayer.SetHandPositions();
                currentPlayer.manaZone.SetPositions(currentPlayer.isPlayerOne);
                //reset for next stage
                ///turnStage = TurnStage.CardCall_Choose;
                selectedCardToManaID = currentPlayer.manaZone.cards.Count - 1;
                selectedCardID = -1;
                selectedCard = null;
            }
        }
        if (inputController.isShiftPressed)
        {
            if (selectedCard != null) { selectedCard.Dehighlight(); }
            ///turnStage = TurnStage.CardCall_Choose;
            selectedCardID = -1;
            selectedCard = null;
        }
    }

    private void ManageCallChooseStage()
    {
        Debug.Log("choose stage");
        if (currentPlayer.hand.Count > 0)
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            selectedCardID = selectedCardID == currentPlayer.hand.Count ? selectedCardID - 1 : selectedCardID;  //select last card if cards amount changed
            selectedCard = currentPlayer.hand[selectedCardID];
            selectedCard.Highlight();
        }
        if (inputController.isLeftArrowPressed)
        {
            if (selectedCardID > 0)
            {
                selectedCard.Dehighlight();
                selectedCardID -= 1;
                selectedCard = currentPlayer.hand[selectedCardID];
                selectedCard.Highlight();
            }
        }
        if (inputController.isRightArrowPressed)
        {
            if (selectedCardID < currentPlayer.hand.Count - 1)
            {
                selectedCard.Dehighlight();
                selectedCardID += 1;
                selectedCard = currentPlayer.hand[selectedCardID];
                selectedCard.Highlight();
            }
        }
        if (inputController.isEnterPressed)
        {
            if (selectedCardID != -1)
            {
                //change "pointers" and go to pay stage
                selectedCardToCallID = selectedCardID;
                selectedCardToCall = currentPlayer.hand[selectedCardToCallID];
                selectedCardID = -1;
                selectedCard = null;
                turnStage = TurnStage.CardCall_Pay;
            }
        }
        if (inputController.isShiftPressed)
        {
            if (selectedCard != null) { selectedCard.Dehighlight(); }
            turnStage = TurnStage.Fight_Choose;
            selectedCard = null;
            selectedCardID = -1;
        }
        if (inputController.isBackspacePressed)
        {
            //move card back to hand
            if (selectedCard != null) { selectedCard.Dehighlight(); }
            if (selectedCardToManaID != -1)
            {
                var card = currentPlayer.GetCardFromList(ref currentPlayer.manaZone.cards, selectedCardToManaID);
                currentPlayer.AddCardToList(ref currentPlayer.hand, card);
            }
            //set positions
            currentPlayer.SetHandPositions();
            currentPlayer.manaZone.SetPositions(currentPlayer.isPlayerOne);
            //reset for mana stage
            turnStage = TurnStage.Mana;
            selectedCardID = -1;
            selectedCard = null;
            selectedCardToManaID = -1;
        }
    }

    private void ManageCallPayStage()
    {
        Debug.Log("pay stage");
        if (currentPlayer.manaZone.cards.Count > 0)
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            selectedCardID = selectedCardID == currentPlayer.manaZone.cards.Count ? selectedCardID - 1 : selectedCardID;  //select last card if cards amount changed
            selectedCard = currentPlayer.manaZone.cards[selectedCardID];
            selectedCard.Highlight();
        }
        if (inputController.isLeftArrowPressed)
        {
            if (selectedCardID > 0)
            {
                selectedCard.Dehighlight();
                selectedCardID -= 1;
                selectedCard = currentPlayer.manaZone.cards[selectedCardID];
                selectedCard.Highlight();
            }
        }
        if (inputController.isRightArrowPressed)
        {
            if (selectedCardID < currentPlayer.manaZone.cards.Count - 1)
            {
                selectedCard.Dehighlight();
                selectedCardID += 1;
                selectedCard = currentPlayer.manaZone.cards[selectedCardID];
                selectedCard.Highlight();
            }
        }
        if (inputController.isEnterPressed)
        {
            if (selectedCardID != -1 && !selectedCard.isTapped)
            {
                if (selectedCard.isManaTapped)
                {
                    selectedCard.ManaUntap();
                    selectedCardToCall.costPaid -= 1;
                }
                else
                {
                    selectedCard.ManaTap();
                    selectedCardToCall.costPaid += 1;
                }
            }
        }
        if (inputController.isShiftPressed)
        {
            if (selectedCardToCall.IsCostPaid())
            {
                //move card
                selectedCard.Dehighlight();
                currentPlayer.manaZone.FinalizeManaTap();
                var card = currentPlayer.GetCardFromList(ref currentPlayer.hand, selectedCardToCallID);
                battlefield.AddCardToBattlefield(card, currentPlayer.isPlayerOne);
                //set positions
                currentPlayer.SetHandPositions();
                battlefield.SetPositions();
                //reset for choose stage
                turnStage = TurnStage.CardCall_Choose;
                selectedCardID = -1;
                selectedCard = null;
                selectedCardToCallID = -1;
                selectedCardToCall = null;
            }
        }
        if (inputController.isBackspacePressed)
        {
            if (selectedCardToCall.costPaid == 0)
            {
                selectedCard.Dehighlight();
                turnStage = TurnStage.CardCall_Choose;
                selectedCardID = selectedCardToCallID;
                selectedCard = currentPlayer.hand[selectedCardID];
                selectedCardToCallID = -1;
                selectedCardToCall = null;
            }
        }
    }

    private void ManageFightChooseStage()
    {
        Debug.Log("fight choose stage");
        if (battlefield.IsCurrentPlayerFieldNotEmpty())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            selectedCardID = selectedCardID == battlefield.currentPlayerCards.Count ? selectedCardID - 1 : selectedCardID;
            selectedCard = battlefield.currentPlayerCards[selectedCardID];
            selectedCard.Highlight();
        }
        if (inputController.isLeftArrowPressed)
        {
            if (selectedCardID > 0)
            {
                selectedCard.Dehighlight();
                selectedCardID -= 1;
                selectedCard = battlefield.currentPlayerCards[selectedCardID];
                selectedCard.Highlight();
            }
        }
        if (inputController.isRightArrowPressed)
        {
            if (selectedCardID < battlefield.currentPlayerCards.Count - 1)
            {
                selectedCard.Dehighlight();
                selectedCardID += 1;
                selectedCard = battlefield.currentPlayerCards[selectedCardID];
                selectedCard.Highlight();
            }
        }
        if (inputController.isEnterPressed)
        {
            if (selectedCardID != -1 && !selectedCard.isTapped)
            {
                selectedCardToFightID = selectedCardID;
                battlefield.currentPlayerCards[selectedCardToFightID].Tap();
                turnStage = TurnStage.Fight_Target;
                selectedCardID = -1;
                selectedCard = null;
            }
        }
        if (inputController.isShiftPressed)
        {
            selectedCard.Dehighlight();
            turnStage = TurnStage.End;
        }
    }

    private void ManageFightTargetStage()
    {
        Debug.Log("fight target stage");
        if (battlefield.IsOtherPlayerFieldNotEmpty())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            selectedCardID = selectedCardID == battlefield.otherPlayerCards.Count ? selectedCardID - 1 : selectedCardID;
            selectedCard = battlefield.otherPlayerCards[selectedCardID];
            selectedCard.Highlight();
        }
        else if (!otherPlayer.shieldZone.IsEmpty())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            selectedCardID = selectedCardID == otherPlayer.shieldZone.shields.Count ? selectedCardID - 1 : selectedCardID;
            selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
            selectedCard.Highlight();
            isShieldTargeted = true;
        }
        if (inputController.isLeftArrowPressed)
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
        if (inputController.isRightArrowPressed)
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
        if (inputController.isUpArrowPressed)
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
        if (inputController.isDownArrowPressed)
        {
            if (isShieldTargeted && battlefield.IsOtherPlayerFieldNotEmpty())
            {
                selectedCard.Dehighlight();
                selectedCardID = 0;
                selectedCard = battlefield.otherPlayerCards[selectedCardID];
                selectedCard.Highlight();
                isShieldTargeted = false;
            }
        }
        if (inputController.isEnterPressed)
        {
            if (selectedCardID != -1)
            {
                if (isShieldTargeted)
                {
                    selectedCard.Dehighlight();
                    battlefield.currentPlayerCards[selectedCardToFightID].Dehighlight();
                    var card = otherPlayer.shieldZone.RemoveShield(selectedCardID);
                    otherPlayer.AddCardToList(ref otherPlayer.hand, card);
                    otherPlayer.SetHandPositions();
                    otherPlayer.shieldZone.SetPositions(otherPlayer.isPlayerOne);
                }
                else
                {
                    turnStage = TurnStage.Battle;
                }
            }
        }
        if (inputController.isBackspacePressed)
        {
            if (selectedCard != null) { selectedCard.Dehighlight(); }
            selectedCardID = selectedCardToFightID;
            selectedCard = battlefield.currentPlayerCards[selectedCardID];
            selectedCardToFightID = -1;
            turnStage = TurnStage.Fight_Choose;
        }
    }

    private void ManageBattleStage()
    {
        Debug.Log("battle stage");
        //handle battle
        turnStage = TurnStage.Fight_Choose;
    }

    private void ManageEndTurn()
    {
        if (currentPlayer.isPlayerOne)
        {
            //currentPlayer.isPlayerOne = false;
            currentPlayer = playerTwo;
            otherPlayer = playerOne;
        }
        else
        {
            //currentPlayer.isPlayerOne = true;
            currentPlayer = playerOne;
            otherPlayer = playerTwo;
        }
        battlefield.SwitchListRef();
        ResetRefs();
        //rotate camera
        turnStage = TurnStage.Mana;
    }


}