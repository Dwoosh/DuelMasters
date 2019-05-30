using UnityEngine;
using System.Collections;

public class HunterFishCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Hunter Fish";
        cardRace = Race.Fish;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 3000;
        cantAttack = true;
        abilities.Add(new Blocker(this));
    }
}
