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
        eventManager.CallOnEndTurnEvent(); //possibility of problem with reference switch?
        currentPlayer.UnsubscribeToTurnEvents(); //unsub cards abilities which invoke only on current player turn
        currentPlayer.SubscribeToOddTurnEvents(); //sub cards abilities which invoke only on other player turn
        stageFSM.SwitchPlayers(); //switch current and other player
        currentPlayer.UnsubscribeToOddTurnEvents();  //unsub cards abilities which invoke only on other player turn
        currentPlayer.SubscribeToTurnEvents();  //sub cards abilities which invoke only on current player turn
        currentPlayer.DrawCard();
        return StageFSM.manaStage;
    }
}
