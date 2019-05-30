using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IereCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Iere, Vizier of Bullets";
        cardRace = Race.Initiate;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 3000;
    }
    
}