using UnityEngine;
using System.Collections;

public class BlockerStage : GameStage
{

    public BlockerStage(StageFSM stageFSM) : base(stageFSM) { }
    
    public bool wasBlocked { get; set; }

    public Card attackerCard { get; set; }
    
    private bool waitingForEvent { get; set; }

    public override GameStage ManageStage()
    {
        eventManager.CallOnBlockerEvent();
        if (waitingForEvent)
        {
            waitingForEvent = false;
            return null;
        }
        if (!wasBlocked && StageFSM.fightTargetShieldStage.selectedCardAsTarget != null)
        { //if wasnt blocked and shield was targeted
            StageFSM.fightChooseStage.selectedCardToFight.Tap();
            otherPlayer.RemoveShieldAddHand(selectedCardID);
            return StageFSM.fightChooseStage;
        }
        else return StageFSM.battleStage;
    }
    
    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("blocker stage");
        wasBlocked = false;
        waitingForEvent = true;
        attackerCard = StageFSM.fightChooseStage.selectedCardToFight;
    }

}
