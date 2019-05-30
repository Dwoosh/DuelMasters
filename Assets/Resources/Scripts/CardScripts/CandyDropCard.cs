using UnityEngine;
using System.Collections;

public class CandyDropCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Candy Drop";
        cardRace = Race.Cyber_Virus;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 1000;
        cantBeBlocked = true;
    }
}
