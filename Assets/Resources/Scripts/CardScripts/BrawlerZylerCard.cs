using UnityEngine;
using System.Collections;

public class BrawlerZylerCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Brawler Zyler";
        cardRace = Race.Human;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 1000;
        powerAttacker = 2000;
    }
}
