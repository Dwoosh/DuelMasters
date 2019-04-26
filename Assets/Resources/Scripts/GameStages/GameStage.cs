using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage
{

    protected int selectedCardID = -1;
    protected Card selectedCard = null;

    protected PlayerScript currentPlayer;
    protected PlayerScript otherPlayer;
    protected InputController inputController;
    protected StageFSM stageFSM;

    public GameStage(StageFSM FSM)
    {
        stageFSM = FSM;
        currentPlayer = stageFSM.currentPlayer;
        otherPlayer = stageFSM.otherPlayer;
        inputController = stageFSM.inputController;
    }

    public virtual GameStage ManageStage() { return null; }

    public virtual void OnLeftArrowPress() { }
    public virtual void OnRightArrowPress() { }
    public virtual void OnUpArrowPress() { }
    public virtual void OnDownArrowPress() { }
    public virtual GameStage OnEnterPress() { return null; }
    public virtual GameStage OnBackspacePress() { return null; }
    public virtual GameStage OnShiftPress() { return null; }

    public virtual void OnStart() {
        currentPlayer = stageFSM.currentPlayer;
        otherPlayer = stageFSM.otherPlayer;
    }

    public virtual void OnEnd() { }

    protected bool IsCardSelected()
    {
        return selectedCard != null;
    }
}
