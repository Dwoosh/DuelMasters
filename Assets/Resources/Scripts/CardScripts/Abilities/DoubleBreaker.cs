using UnityEngine;
using System.Collections;

public class DoubleBreaker : IAbility
{
    public void SubscribeToEvent()
    {
        EventManager.OnShieldAttackEvent += AddScriptToQueue;
    }

    public void UnsubscribeToEvent()
    {
        EventManager.OnShieldAttackEvent -= AddScriptToQueue;
    }
    
    public void AddScriptToQueue()
    {
        EventQueue.Enqueue(DoubleBreakerCoroutine);
    }

    public IEnumerator DoubleBreakerCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer, 
        InputController inputController, Battlefield battlefield, EventManager eventManager)
    {
        int selectedCardID = -1;
        Card selectedCard = null;
        if (!otherPlayer.shieldZone.IsEmpty())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
            selectedCard.Highlight();
            StageFSM.fightChooseStage.selectedCardToFight.Highlight();
            while (true)
            {
                if (inputController.isLeftArrowPressed)
                {
                    if (selectedCardID > 0)
                    {
                        selectedCard.Dehighlight();
                        selectedCardID -= 1;
                        selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
                        selectedCard.Highlight();
                    }
                }
                if (inputController.isRightArrowPressed)
                {
                    if (selectedCardID < otherPlayer.shieldZone.shields.Count - 1)
                    {
                        selectedCard.Dehighlight();
                        selectedCardID += 1;
                        selectedCard = otherPlayer.shieldZone.shields[selectedCardID];
                        selectedCard.Highlight();
                    }
                }
                if (inputController.isEnterPressed)
                {
                    selectedCard.Dehighlight();
                    StageFSM.fightChooseStage.selectedCardToFight.Dehighlight();
                    
                    eventManager.CallOnShieldAttackEvent();

                    var card = otherPlayer.shieldZone.RemoveShield(selectedCardID);
                    otherPlayer.AddCardToList(ref otherPlayer.hand, card);
                    otherPlayer.SetHandPositions();
                    otherPlayer.shieldZone.SetPositions(otherPlayer.isPlayerOne);
                    break;
                }
                yield return null;
            }
        }
        QueueControl.SignalCoroutineEnd();
    }

}
