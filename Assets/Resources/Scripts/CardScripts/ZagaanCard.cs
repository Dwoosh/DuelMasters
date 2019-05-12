using UnityEngine;
using System.Collections;

public class ZagaanCard : Card
{

    public DoubleBreaker doubleBreaker;

    void Start()
    {
        BaseStart();
        cardName = "Zagaan, Knight of Darkness";
        cardRace = Enums.Race.Demon_Command;
        cardCiv = Enums.Civilization.Darkness;
        cardType = Enums.Type.Creature;
        manaCost = 6;
        cardPower = 7000;
        doubleBreaker = new DoubleBreaker();
    }

    void Update()
    {
        BaseUpdate();
    }


    public override void OnShieldAttack()
    {
        doubleBreaker.SubscribeToEvent();
    }

    public override void OnAfterShieldAttack()
    {
        doubleBreaker.UnsubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        doubleBreaker.UnsubscribeToEvent();
    }
}
