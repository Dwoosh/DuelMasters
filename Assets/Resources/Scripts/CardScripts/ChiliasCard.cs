﻿using UnityEngine;
using System.Collections;

public class ChiliasCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Chilias, the Oracle";
        cardRace = Enums.Race.Light_Bringer;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 4;
        cardPower = 2500;
        abilities.Add(new OnDeathReturnToHand(this));
    }
    
}
