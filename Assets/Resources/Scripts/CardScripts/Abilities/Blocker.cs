﻿using UnityEngine;
using System.Collections;

public class Blocker : Ability
{
    private Card attackerCard;
    private Card ownerCard;

    public Blocker(Card owner)
    {
        ownerCard = owner;
    }

    public override void SubscribeToOddTurnEvents()
    {
        SubscribeToEvent();
    }

    public override void UnsubscribeToOddTurnEvents()
    {
        UnsubscribeToEvent();
    }

    public override void OnCall()
    {
        SubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        UnsubscribeToEvent();
    }

    public override void AddScriptToQueue()
    {
        EventQueue.Enqueue(BlockerCoroutine);
    }

    public override void SubscribeToEvent()
    {
        EventManager.OnBlockerEvent += AddScriptToQueue;
    }

    public override void UnsubscribeToEvent()
    {
        EventManager.OnBlockerEvent -= AddScriptToQueue;
    }

    public IEnumerator BlockerCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        attackerCard = StageFSM.fightChooseStage.selectedCardToFight;
        if (!ownerCard.isTapped)
        {
            while (true)
            {
                if (inputController.isEnterPressed)
                {
                    EventQueue.Clear(); //this blocker handled so other blockers are not needed
                    ownerCard.Tap();
                    int battleResult = ownerCard.Battle(attackerCard);
                    if (battleResult != -1) //if it kills attackerCard or both
                    {
                        //kill attacker
                        currentPlayer.RemoveFieldAddGraveyard(attackerCard);
                    }
                    if (battleResult != 1) //if it kills blocker or both
                    {
                        //kill blocker
                        otherPlayer.RemoveFieldAddGraveyard(ownerCard);
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
