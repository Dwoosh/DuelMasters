using UnityEngine;
using System.Collections;

public class ZagaanCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Zagaan, Knight of Darkness";
        cardRace = Enums.Race.Demon_Command;
        cardCiv = Enums.Civilization.Darkness;
        cardType = Enums.Type.Creature;
        manaCost = 6;
        cardPower = 7000;
        abilities.Add(new DoubleBreaker());
    }
    
}
