using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage
{

    protected int selectedCardID = -1;
    protected Card selectedCard = null;
    public virtual string controlsText { get; set; }
    public virtual string infoText { get; set; }

    public static StageFSM stageFSM;
    protected static PlayerScript currentPlayer;
    protected static PlayerScript otherPlayer;
    protected static InputController inputController;
    protected static EventManager eventManager;
    protected static UITextController textController = new UITextController();

    public GameStage(StageFSM FSM)
    {
        stageFSM = FSM;
        currentPlayer = stageFSM.currentPlayer;
        otherPlayer = stageFSM.otherPlayer;
        inputController = stageFSM.inputController;
        eventManager = stageFSM.eventManager;
        controlsText = "Controls:";
        infoText = string.Empty;
    }

    public virtual GameStage ManageStage() {
        UpdateInfoText();
        return null;
    }

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

        UpdateControlsText();
    }

    public virtual void OnEnd() { }

    public void UpdateControlsText()
    {
        textController.UpdateControlsText(controlsText);
    }

    public void UpdateInfoText()
    {
        textController.UpdateInfoText(infoText);
    }

    public static void UpdatePlayers()
    {
        currentPlayer = stageFSM.currentPlayer;
        otherPlayer = stageFSM.otherPlayer;
    }

    protected bool IsCardSelected()
    {
        return selectedCard != null;
    }
}
