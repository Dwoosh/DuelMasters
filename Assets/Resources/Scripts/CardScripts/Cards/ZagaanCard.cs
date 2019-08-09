using UnityEngine;
using System.Collections;

public class ZagaanCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Zagaan, Knight of Darkness";
        cardRace = Race.Demon_Command;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 6;
        cardPower = 7000;
        abilities.Add(new DoubleBreaker());
    }
    
}
