using UnityEngine;
using System.Collections;

public class FireSweeperBurningHellionCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Fire Sweeper Burning Hellion";
        cardRace = Race.Dragonoid;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 3000;
        powerAttacker = 2000;
    }
    
}
