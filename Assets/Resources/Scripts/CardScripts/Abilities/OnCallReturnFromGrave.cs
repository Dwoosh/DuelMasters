using UnityEngine;
using System.Collections;

public class OnCallReturnFromGrave : OnCallAbility
{
    private Card selectedCard = null;
    private int selectedCardID = -1;

    private PlayerScript owner { get; set; }
    private System.Func<Card, bool> comparingFunction { get; set; }
    private int toReturn { get; set; }

    public OnCallReturnFromGrave(PlayerScript player, int count, System.Func<Card, bool> function)
    {
        owner = player;
        comparingFunction = function;
        toReturn = count;
    }

    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        int count = Mathf.Min(owner.GetGraveCount(), toReturn);
        selectedCardID = 0;
        selectedCard = owner.GetGraveAt(selectedCardID);
        while (count != 0)
        {
            if (inputController.isLeftArrowPressed)
            {
                if (selectedCardID > 0)
                {
                    selectedCardID -= 1;
                    selectedCard = owner.GetGraveAt(selectedCardID);
                }
            }
            if (inputController.isRightArrowPressed)
            {
                if (selectedCardID < count - 1)
                {
                    selectedCardID += 1;
                    selectedCard = owner.GetGraveAt(selectedCardID);
                }
            }
            if (inputController.isEnterPressed)
            {
                if (comparingFunction.Invoke(selectedCard))
                {
                    owner.RemoveGraveyardAddHand(selectedCard);
                    count -= 1;
                }
            }
            if (inputController.isBackspacePressed)
            {
                count -= 1;
            }
            yield return null;
        }
        QueueControl.SignalCoroutineEnd();
    }

}
