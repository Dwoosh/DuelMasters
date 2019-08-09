using UnityEngine;
using System.Collections;

public class FearFangCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Fear Fang";
        cardRace = Race.Beast_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 3000;
    }
}
