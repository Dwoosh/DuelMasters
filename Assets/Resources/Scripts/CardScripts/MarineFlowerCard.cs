using UnityEngine;
using System.Collections;

public class MarineFlowerCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Marine Flower";
        cardRace = Race.Cyber_Virus;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 1;
        cardPower = 2000;
        abilities.Add(new Blocker(this));
        cantAttack = true;
    }
}
