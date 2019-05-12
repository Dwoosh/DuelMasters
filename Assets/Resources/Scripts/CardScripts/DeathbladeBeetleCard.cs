using UnityEngine;
using System.Collections;

public class DeathbladeBeetleCard : Card
{

    public DoubleBreaker doubleBreaker;

    void Start()
    {
        BaseStart();
        cardName = "Deathblade Beetle";
        cardRace = Enums.Race.Giant_Insect;
        cardCiv = Enums.Civilization.Nature;
        cardType = Enums.Type.Creature;
        manaCost = 5;
        cardPower = 3000;
        powerAttacker = 4000;
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
