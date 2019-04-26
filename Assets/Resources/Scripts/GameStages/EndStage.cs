using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStage : GameStage
{
    public Battlefield battlefield { get; set; }

    public EndStage(StageFSM stageFSM) : base(stageFSM) {
        battlefield = stageFSM.battlefield;
    }

    public override GameStage ManageStage()
    {
        stageFSM.SwitchPlayers();
        battlefield.SwitchListRef();
        return StageFSM.manaStage;
    }
}
