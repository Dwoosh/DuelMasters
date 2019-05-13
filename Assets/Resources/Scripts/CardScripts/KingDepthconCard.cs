using UnityEngine;
using System.Collections;

public class KingDepthconCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "King Depthcon";
        cardRace = Enums.Race.Leviathan;
        cardCiv = Enums.Civilization.Water;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 6000;
        abilities.Add(new DoubleBreaker());
        cantBeBlocked = true;
    }
    
}
