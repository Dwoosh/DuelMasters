using UnityEngine;
using System.Collections;

public class KingCoralCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "King Coral";
        cardRace = Race.Leviathan;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 1000;
        abilities.Add(new Blocker(this));
    }
}
