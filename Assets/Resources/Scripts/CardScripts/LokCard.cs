using UnityEngine;
using System.Collections;

public class LokCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Lok, Vizier of Hunting";
        cardRace = Race.Initiate;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 4000;
    }
}
