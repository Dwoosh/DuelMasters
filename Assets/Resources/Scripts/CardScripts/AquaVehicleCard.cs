using UnityEngine;
using System.Collections;

public class AquaVehicleCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Aqua Vehicle";
        cardRace = Race.Liquid_People;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 1000;
    }
}
