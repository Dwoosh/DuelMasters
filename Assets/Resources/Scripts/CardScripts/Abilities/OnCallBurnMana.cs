using UnityEngine;
using System.Collections;

public class OnCallBurnMana : OnCallAbility
{

    private int actionCount { get; set; }

    private int selectedCardID = -1;
    private Card selectedCard = null;

    public OnCallBurnMana(int count)
    {
        actionCount = count;
    }

    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        int count = Mathf.Min(actionCount, currentPlayer.GetManaCount());
        if(count != 0)
        {
            selectedCardID = 0;
            selectedCard = currentPlayer.GetManaAt(selectedCardID);
        }
        while (count != 0)
        {
            if (inputController.isLeftArrowPressed)
            {
                OnLeftArrowPress(currentPlayer);
            }
            if (inputController.isRightArrowPressed)
            {
                OnRightArrowPress(currentPlayer);
            }
            if (inputController.isEnterPressed)
            {
                selectedCard.Dehighlight();
                currentPlayer.RemoveManaAddGraveyard(selectedCardID);
                count -= 1;
            }
            yield return null;
        }
        QueueControl.SignalCoroutineEnd();
    }

    private void OnLeftArrowPress(PlayerScript player)
    {
        if (selectedCardID > 0)
        {
            selectedCard.Dehighlight();
            selectedCardID -= 1;
            selectedCard = player.GetManaAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    private void OnRightArrowPress(PlayerScript player)
    {
        if (selectedCardID < player.GetManaCount() - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = player.GetManaAt(selectedCardID);
            selectedCard.Highlight();
        }
    }
}
