using UnityEngine;
using System.Collections;

public class TowerShellCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Tower Shell";
        cardRace = Race.Colony_Beetle;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 6;
        cardPower = 5000;
        cantBeBlockedCondition = (blocker) => { return blocker.cardPower <= 4000; };
    }
}
