using UnityEngine;
using System.Collections;

public class DeathligerCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Deathliger, Lion of Chaos";
        cardRace = Enums.Race.Demon_Command;
        cardCiv = Enums.Civilization.Darkness;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 9000;
        abilities.Add(new DoubleBreaker());
    }
    
}
