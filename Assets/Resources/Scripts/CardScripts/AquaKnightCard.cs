using UnityEngine;
using System.Collections;

public class AquaKnightCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Aqua Knight";
        cardRace = Race.Liquid_People;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 4000;
        abilities.Add(new OnDeathReturnToHand(this));
    }
}
