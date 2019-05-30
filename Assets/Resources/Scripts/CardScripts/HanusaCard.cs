using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanusaCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Hanusa, Radiance Elemental";
        cardRace = Race.Angel_Command;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 7;
        cardPower = 9500;
        abilities.Add(new DoubleBreaker());
    }
    
}