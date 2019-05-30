using UnityEngine;
using System.Collections;

public class LahCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Lah, Purification Enforcer";
        cardRace = Race.Berserker;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 5500;
    }
}
