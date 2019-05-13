using UnityEngine;
using System.Collections;

//Double Breaker ability - if any shields exists, it allows to destroy additional one - first one is already being destroyed in stage
public class DoubleBreaker : Ability
{
    private int selectedCardID = -1;
    private Card selectedCard = null;

    public override void OnShieldAttack()
    {
        SubscribeToEvent();
    }

    public override void OnAfterShieldAttack()
    {
        UnsubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        UnsubscribeToEvent();
    }

    public override void SubscribeToEvent()
    {
        EventManager.OnShieldAttackEvent += AddScriptToQueue;
    }

    public override void UnsubscribeToEvent()
    {
        EventManager.OnShieldAttackEvent -= AddScriptToQueue;
    }
    
    public override void AddScriptToQueue()
    {
        EventQueue.Enqueue(DoubleBreakerCoroutine);
    }

    public IEnumerator DoubleBreakerCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer, 
        InputController inputController)
    {
        if (!otherPlayer.shieldZone.IsEmpty())
        {
            selectedCardID = selectedCardID == -1 ? 0 : selectedCardID;   //select first card if there are any
            selectedCard = otherPlayer.GetShieldAt(selectedCardID);
            selectedCard.Highlight();
            StageFSM.fightChooseStage.selectedCardToFight.Highlight();
            while (true)
            {
                if (inputController.isLeftArrowPressed)
                {
                    OnLeftArrowPress(otherPlayer);
                }
                if (inputController.isRightArrowPressed)
                {
                    OnRightArrowPress(otherPlayer);
                }
                if (inputController.isEnterPressed)
                {
                    selectedCard.Dehighlight();
                    StageFSM.fightChooseStage.selectedCardToFight.Dehighlight();
                    otherPlayer.RemoveShieldAddHand(selectedCardID);
                    break;
                }
                yield return null;
            }
        }
        QueueControl.SignalCoroutineEnd();
    }

    private void OnRightArrowPress(PlayerScript otherPlayer)
    {
        if (selectedCardID < otherPlayer.GetShieldCount() - 1)
        {
            selectedCard.Dehighlight();
            selectedCardID += 1;
            selectedCard = otherPlayer.GetShieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

    private void OnLeftArrowPress(PlayerScript otherPlayer)
    {
        if (selectedCardID > 0)
        {
            selectedCard.Dehighlight();
            selectedCardID -= 1;
            selectedCard = otherPlayer.GetShieldAt(selectedCardID);
            selectedCard.Highlight();
        }
    }

}
