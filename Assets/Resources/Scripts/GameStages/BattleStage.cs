using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStage : GameStage
{
    public Card attackerCard { get; set; }
    public Card targetCard { get; set; }

    public BattleStage(StageFSM stageFSM) : base(stageFSM) {
        attackerCard = null;
        targetCard = null;
    }

    public override GameStage ManageStage()
    {
        HandleBattle();
        return StageFSM.fightChooseStage;
    }

    private void HandleBattle()
    {
        if(attackerCard == null || targetCard == null) {
            Debug.LogException(new System.Exception("One of card references was null"));
        }
        int battleResult = attackerCard.Battle(targetCard);
        if(battleResult == 1)
        {
            //kill target
        }
        else if(battleResult == 0)
        {
            //kill both
        }
        else
        {
            //kill attacker
        }
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("battle stage");
        attackerCard = StageFSM.fightChooseStage.selectedCardToFight;
        targetCard = StageFSM.fightTargetStage.selectedCardAsTarget;
        //selectedCardID = -1;
        //selectedCard = null;
    }
}
