using UnityEngine;
using System.Collections;

public class AquaSniperCard : Card
{

    public OnCallReturnToHand onCallReturn;

    void Start()
    {
        BaseStart();
        cardName = "Aqua Sniper";
        cardRace = Enums.Race.Liquid_People;
        cardCiv = Enums.Civilization.Water;
        cardType = Enums.Type.Creature;
        manaCost = 8;
        cardPower = 5000;
        onCallReturn = new OnCallReturnToHand(2);
    }

    void Update()
    {
        BaseUpdate();
    }

    public override void OnCall()
    {
        base.OnCall();
        onCallReturn.SubscribeToEvent();
    }

    public override void OnAfterCall()
    {
        onCallReturn.UnsubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        onCallReturn.UnsubscribeToEvent();
    }

}
