using UnityEngine;
using System.Collections;

public class AstrocometDragonCard : Card
{

    public DoubleBreaker doubleBreaker;

    void Start()
    {
        BaseStart();
        cardName = "Astrocomet Dragon";
        cardRace = Enums.Race.Armored_Dragon;
        cardCiv = Enums.Civilization.Fire;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 6000;
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
