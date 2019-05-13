using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanusaCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Hanusa, Radiance Elemental";
        cardRace = Enums.Race.Angel_Command;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 9500;
        abilities.Add(new DoubleBreaker());
    }
    
}