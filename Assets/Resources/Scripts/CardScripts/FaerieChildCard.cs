using UnityEngine;
using System.Collections;

public class FaerieChildCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Faerie Child";
        cardRace = Race.Cyber_Virus;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 2000;
        cantBeBlocked = true;
    }
}
