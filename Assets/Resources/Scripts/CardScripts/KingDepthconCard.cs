using UnityEngine;
using System.Collections;

public class KingDepthconCard : Card
{
    public DoubleBreaker doubleBreaker;

    void Start()
    {
        BaseStart();
        cardName = "King Depthcon";
        cardRace = Enums.Race.Leviathan;
        cardCiv = Enums.Civilization.Water;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 6000;
        doubleBreaker = new DoubleBreaker();
        cantBeBlocked = true;
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
