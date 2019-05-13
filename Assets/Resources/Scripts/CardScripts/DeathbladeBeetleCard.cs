using UnityEngine;
using System.Collections;

public class DeathbladeBeetleCard : Card
{
    void Start()
    {
        BaseStart();
        cardName = "Deathblade Beetle";
        cardRace = Enums.Race.Giant_Insect;
        cardCiv = Enums.Civilization.Nature;
        cardType = Enums.Type.Creature;
        manaCost = 5;
        cardPower = 3000;
        powerAttacker = 4000;
        abilities.Add(new DoubleBreaker());
    }
    
}
