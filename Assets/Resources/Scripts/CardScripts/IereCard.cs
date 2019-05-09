using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IereCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Iere, Vizier of Bullets";
        cardRace = Enums.Race.Initiate;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 3;
        cardPower = 3000;
    }

    void Update()
    {
        BaseUpdate();
    }
}