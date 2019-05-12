using UnityEngine;
using System.Collections;

public class RoaringGreathornCard : Card
{

    public DoubleBreaker doubleBreaker;

    void Start()
    {
        BaseStart();
        cardName = "Roaring Great-Horn";
        cardRace = Enums.Race.Horned_Beast;
        cardCiv = Enums.Civilization.Nature;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 8000;
        powerAttacker = 2000;
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
