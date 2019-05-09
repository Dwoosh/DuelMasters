using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanusaCard : Card
{

    private DoubleBreaker doubleBreaker;

    void Start()
    {
        BaseStart();
        cardName = "Hanusa, Radiance Elemental";
        cardRace = Enums.Race.Angel_Command;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 9500;
        doubleBreaker = new DoubleBreaker();
    }

    void Update()
    {
        BaseUpdate();
    }

    public override void OnCall()
    {
        doubleBreaker.SubscribeToEvent();
    }

    public override void OnDeath()
    {
        doubleBreaker.UnsubscribeToEvent();
    }

}