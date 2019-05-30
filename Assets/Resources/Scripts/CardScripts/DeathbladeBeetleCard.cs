using UnityEngine;
using System.Collections;

public class DeathbladeBeetleCard : Card
{
    void Start()
    {
        BaseStart();
        cardName = "Deathblade Beetle";
        cardRace = Race.Giant_Insect;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 3000;
        powerAttacker = 4000;
        abilities.Add(new DoubleBreaker());
    }
    
}
