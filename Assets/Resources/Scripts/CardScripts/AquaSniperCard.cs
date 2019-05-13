using UnityEngine;
using System.Collections;

public class AquaSniperCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Aqua Sniper";
        cardRace = Enums.Race.Liquid_People;
        cardCiv = Enums.Civilization.Water;
        cardType = Enums.Type.Creature;
        manaCost = 8;
        cardPower = 5000;
        abilities.Add(new OnCallReturnToHand(2));
    }

}
