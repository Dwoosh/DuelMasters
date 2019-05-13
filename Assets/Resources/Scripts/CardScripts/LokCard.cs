using UnityEngine;
using System.Collections;

public class LokCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Lok, Vizier of Hunting";
        cardRace = Enums.Race.Initiate;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 4;
        cardPower = 4000;
    }
}
