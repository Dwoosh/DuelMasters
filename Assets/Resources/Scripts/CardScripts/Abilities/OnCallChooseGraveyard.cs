using UnityEngine;
using System.Collections;

public class OnCallChooseGraveyard : OnCallAbility
{

    private System.Action<Card, PlayerScript> cardAction { get; set; }

    private int selectedCardID = -1;
    private Card selectedCard = null;

    public OnCallChooseGraveyard(System.Action<Card, PlayerScript> action)
    {
        cardAction = action;
    }

    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer, InputController inputController)
    {
        int count = currentPlayer.GetGraveCount();
        if (count != 0)
        {
            selectedCardID = 0;
            selectedCard = currentPlayer.GetGraveAt(selectedCardID);
            while (true)
            {
                if (inputController.isLeftArrowPressed)
                {
                    if (selectedCardID > 0)
                    {
                        selectedCardID -= 1;
                        selectedCard = currentPlayer.GetGraveAt(selectedCardID);
                    }
                }
                if (inputController.isRightArrowPressed)
                {
                    if (selectedCardID < count - 1)
                    {
                        selectedCardID += 1;
                        selectedCard = currentPlayer.GetGraveAt(selectedCardID);
                    }
                }
                if (inputController.isEnterPressed)
                {
                    cardAction.Invoke(selectedCard, currentPlayer);
                    break;
                }
                if (inputController.isBackspacePressed)
                {
                    break;
                }
                yield return null;
            }
        }
        QueueControl.SignalCoroutineEnd();
    }
}
