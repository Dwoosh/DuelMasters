﻿using UnityEngine;
using System.Collections;

public class PhantomFishCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Phantom Fish";
        cardRace = Race.Gel_Fish;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 4000;
        abilities.Add(new Blocker(this));
        cantAttack = true;
    }
}
