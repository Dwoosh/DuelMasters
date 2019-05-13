using UnityEngine;
using System.Collections;

public class LahCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Lah, Purification Enforcer";
        cardRace = Enums.Race.Berserker;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 5;
        cardPower = 5500;
    }
}
