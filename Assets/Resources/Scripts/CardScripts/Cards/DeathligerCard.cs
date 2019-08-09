using UnityEngine;
using System.Collections;

public class DeathligerCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Deathliger, Lion of Chaos";
        cardRace = Race.Demon_Command;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 7;
        cardPower = 9000;
        abilities.Add(new DoubleBreaker());
    }
    
}
