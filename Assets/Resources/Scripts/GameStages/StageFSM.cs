using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: make onEnd write selectedCardID = selectedToMana or selectedToFight?
//TODO: changes in gamestages: remove selectCard setting in each frame

public class StageFSM : MonoBehaviour
{
    public PlayerScript currentPlayer { get; set; }
    public PlayerScript otherPlayer { get; set; }

    public PlayerScript playerOne;
    public PlayerScript playerTwo;
    public InputController inputController;
    public Battlefield battlefield;
    public EventManager eventManager;
    public GameObject gameCamera;

    public GameStage currentGameStage = null;

    public QueueControl queueControl;

    public static ManaStage manaStage;
    public static CardCallChooseStage callChooseStage;
    public static CardCallPayStage callPayStage;
    public static FightChooseStage fightChooseStage;
    public static FightTargetFieldStage fightTargetFieldStage;
    public static FightTargetShieldStage fightTargetShieldStage;
    public static BlockerStage blockerStage;
    public static BattleStage battleStage;
    public static EndStage endStage;

    void Start()
    {
        currentPlayer = playerOne;
        otherPlayer = playerTwo;
        manaStage = new ManaStage(this);
        callChooseStage = new CardCallChooseStage(this);
        callPayStage = new CardCallPayStage(this);
        fightChooseStage = new FightChooseStage(this);
        fightTargetFieldStage = new FightTargetFieldStage(this);
        fightTargetShieldStage = new FightTargetShieldStage(this);
        blockerStage = new BlockerStage(this);
        battleStage = new BattleStage(this);
        endStage = new EndStage(this);
        currentGameStage = manaStage;
    }

    void Update()
    {
        inputController.PollForInput();
        
        if (queueControl.CheckQueue()) { }
        else
        {
            GameStage stage = currentGameStage.ManageStage();
            if (stage != null)
            {
                currentGameStage.OnEnd();
                currentGameStage = stage;
                currentGameStage.OnStart();
            }
        }
    }

    public void SwitchPlayers()
    {
        queueControl.SwitchPlayers();
        battlefield.SwitchListRef();
        if (currentPlayer.Equals(playerOne))
        {
            currentPlayer = playerTwo;
            otherPlayer = playerOne;
            MoveCameraToPlayerTwo();
        }
        else
        {
            currentPlayer = playerOne;
            otherPlayer = playerTwo;
            MoveCameraToPlayerOne();
        }
        GameStage.UpdatePlayers();
    }

    private void MoveCameraToPlayerOne()
    {
        gameCamera.transform.position -= 58f * Vector3.forward;
        gameCamera.transform.eulerAngles = new Vector3(54f, 0, 0);
    }

    private void MoveCameraToPlayerTwo()
    {
        gameCamera.transform.position += 58f * Vector3.forward;
        gameCamera.transform.eulerAngles = new Vector3(54f, 180f, 0);
    }
}
