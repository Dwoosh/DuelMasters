using UnityEngine;
using System.Collections;

public class DiaNorkCard : Card
{

    public Blocker blocker;

    void Start()
    {
        BaseStart();
        cardName = "Dia Nork, Moonlight Guardian";
        cardRace = Enums.Race.Guardian;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 4;
        cardPower = 5000;
        blocker = new Blocker(this);
        cantAttackPlayers = true;
    }

    void Update()
    {
        BaseUpdate();
    }

    public override void SubscribeToOddTurnEvents()
    {
        blocker.SubscribeToEvent();
    }

    public override void UnsubscribeToOddTurnEvents()
    {
        blocker.UnsubscribeToEvent();
    }

    public override void OnCall()
    {
        base.OnCall();
        blocker.SubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        blocker.UnsubscribeToEvent();
    }

}
