using UnityEngine;
using System.Collections;

public class SuperExplosiveVolcanodonCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Super Explosive Volcanodon";
        cardRace = Race.Dragonoid;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 2000;
        powerAttacker = 4000;
    }
}
