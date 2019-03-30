using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IereCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Iere";
        cardRace = "Initiate";
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 1;
        cardPower = 3000;
    }

    void Update()
    {
        BaseUpdate();

    }
}