﻿using UnityEngine;
using System.Collections;

public class DiaNorkCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Dia Nork, Moonlight Guardian";
        cardRace = Enums.Race.Guardian;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 4;
        cardPower = 5000;
        abilities.Add(new Blocker(this));
        cantAttackPlayers = true;
    }
    
}
