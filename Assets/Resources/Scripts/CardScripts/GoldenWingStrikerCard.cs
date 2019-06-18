using UnityEngine;
using System.Collections;

public class GoldenWingStrikerCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Golden Wing Striker";
        cardRace = Race.Beast_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 2000;
        powerAttacker = 2000;
    }
}
