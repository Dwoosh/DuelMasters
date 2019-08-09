using UnityEngine;
using System.Collections;

public class BurningManeCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Burning Mane";
        cardRace = Race.Beast_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 2000;
    }
}
