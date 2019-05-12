using UnityEngine;
using System.Collections;

public class DeathligerCard : Card
{
    public DoubleBreaker doubleBreaker;

    void Start()
    {
        BaseStart();
        cardName = "Deathliger, Lion of Chaos";
        cardRace = Enums.Race.Demon_Command;
        cardCiv = Enums.Civilization.Darkness;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 9000;
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
