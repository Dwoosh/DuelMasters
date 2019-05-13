using UnityEngine;
using System.Collections;

public class LaserWingCard : SpellCard
{

    private Card firstCard = null;
    private Card secondCard = null;
    private int cardsToChoose = 2;
    private int selectedCardID = -1;
    private Card selectedCard = null;

    void Start()
    {
        SpellStart();
        cardName = "Laser Wing";
        cardCiv = Enums.Civilization.Light;
        manaCost = 5;
    }

    public override void SpellAbility()
    {
        EventQueue.Enqueue(ChooseCoroutine);
        EventManager.OnEndTurnEvent += RemoveAbilities;
    }

    private void RemoveAbilities()
    {
        if(firstCard != null) { firstCard.cantBeBlocked = false; }
        if(secondCard != null) { secondCard.cantBeBlocked = false; }
        EventManager.OnEndTurnEvent -= RemoveAbilities; //unsubscribe itself after its done
    }

    public IEnumerator ChooseCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        while(cardsToChoose != 0)
        {
            if(selectedCardID == -1 && owner.IsFieldNotEmpty())
            {
                selectedCardID = 0;   //select first card if there are any
                selectedCard = owner.GetFieldAt(selectedCardID);
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
                if (selectedCard != null && firstCard != selectedCard) {
                    firstCard = selectedCard;
                    cardsToChoose -= 1;
                }
            }
            if (inputController.isBackspacePressed)
            {
                cardsToChoose -= 1;
            }
            yield return null;
        }
        QueueControl.SignalCoroutineEnd();
    }

    private void OnLeftArrowPress()
    {
        if (selectedCardID > 0)
        {
            selectedCard.Dehighlight();
            selectedCardID -= 1;
            selectedCard = owner.GetFieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    private void OnRightArrowPress()
    {
        if (selectedCardID < owner.GetFieldCount() - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = owner.GetFieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

}
