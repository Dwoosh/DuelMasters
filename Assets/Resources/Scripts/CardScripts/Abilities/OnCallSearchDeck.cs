using UnityEngine;
using System.Collections;

//"When you put this creature into the battle zone, search your deck..." ability
//TODO: show card to opponent when chosen, add option "no show"
public class OnCallSearchDeck : OnCallAbility
{

    private static UITextController textController = new UITextController();

    private Card selectedCard = null;
    private int selectedCardID = -1;

    private PlayerScript owner { get; set; }
    private System.Func<Card, bool> comparingFunction { get; set; }

    public OnCallSearchDeck(PlayerScript player, System.Func<Card, bool> function)
    {
        owner = player;
        comparingFunction = function;
    }

    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer, InputController inputController)
    {
        int count = owner.GetDeckCount();
        if(count != 0) {
            selectedCardID = 0;
            selectedCard = owner.GetDeckAt(selectedCardID);
            while (true)
            {
                if (inputController.isLeftArrowPressed)
                {
                    if(selectedCardID > 0)
                    {
                        selectedCardID -= 1;
                        selectedCard = owner.GetDeckAt(selectedCardID);
                        textController.UpdateInfoText(selectedCard.cardName);
                    }
                }
                if (inputController.isRightArrowPressed)
                {
                    if (selectedCardID < count - 1)
                    {
                        selectedCardID += 1;
                        selectedCard = owner.GetDeckAt(selectedCardID);
                        textController.UpdateInfoText(selectedCard.cardName);
                    }
                }
                if (inputController.isEnterPressed)
                {
                    if (comparingFunction.Invoke(selectedCard))
                    {
                        owner.RemoveDeckAddHand(selectedCardID);
                        //show opponent
                        owner.deck.Shuffle();
                        break;
                    }
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
