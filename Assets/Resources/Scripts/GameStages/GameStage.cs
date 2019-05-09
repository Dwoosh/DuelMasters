using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage
{

    protected int selectedCardID = -1;
    protected Card selectedCard = null;
    public string controlsText = "Controls:";
    public string infoText = "";

    protected PlayerScript currentPlayer;
    protected PlayerScript otherPlayer;
    protected InputController inputController;
    protected StageFSM stageFSM;
    protected EventManager eventManager;
    protected static UITextController textController = new UITextController();

    public GameStage(StageFSM FSM)
    {
        stageFSM = FSM;
        currentPlayer = stageFSM.currentPlayer;
        otherPlayer = stageFSM.otherPlayer;
        inputController = stageFSM.inputController;
        eventManager = stageFSM.eventManager;
    }

    public virtual GameStage ManageStage() { return null; }

    public virtual void OnLeftArrowPress() { }
    public virtual void OnRightArrowPress() { }
    public virtual GameStage OnUpArrowPress() { return null; }
    public virtual GameStage OnDownArrowPress() { return null; }
    public virtual GameStage OnEnterPress() { return null; }
    public virtual GameStage OnBackspacePress() { return null; }
    public virtual GameStage OnShiftPress() { return null; }

    public virtual void OnStart() {
        currentPlayer = stageFSM.currentPlayer;
        otherPlayer = stageFSM.otherPlayer;

        textController.UpdateControlsText(controlsText);
        textController.UpdateInfoText(infoText);
    }

    public virtual void OnEnd() { }

    protected bool IsCardSelected()
    {
        return selectedCard != null;
    }
}
