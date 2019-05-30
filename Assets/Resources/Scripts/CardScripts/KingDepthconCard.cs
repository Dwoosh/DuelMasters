using UnityEngine;
using System.Collections;

public class KingDepthconCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "King Depthcon";
        cardRace = Race.Leviathan;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 7;
        cardPower = 6000;
        abilities.Add(new DoubleBreaker());
        cantBeBlocked = true;
    }
    
}
