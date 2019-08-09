using UnityEngine;
using System.Collections;

public class SeamineCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Seamine";
        cardRace = Race.Fish;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 6;
        cardPower = 4000;
        abilities.Add(new Blocker(this));
    }
}
