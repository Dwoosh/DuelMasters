using UnityEngine;
using System.Collections;

public class BlockerStage : GameStage
{

    public BlockerStage(StageFSM stageFSM) : base(stageFSM) { }

    public GameStage nextStage { get; set; }

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
        if (!wasBlocked)
        {
            if (nextStage.Equals(StageFSM.fightChooseStage))//shield was chosen
            {
                otherPlayer.RemoveShieldAddHand(selectedCardID);
            }
            return nextStage;
        }
        else return StageFSM.fightChooseStage;
    }
    
    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("blocker stage");
        nextStage = StageFSM.battleStage;
        wasBlocked = false;
        waitingForEvent = true;
        attackerCard = StageFSM.fightChooseStage.selectedCardToFight;
    }

}
