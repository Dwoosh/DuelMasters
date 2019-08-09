using UnityEngine;
using System.Collections;

public class ReusolCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Reusol, the Oracle";
        cardRace = Race.Light_Bringer;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 2000;
    }
    
}
