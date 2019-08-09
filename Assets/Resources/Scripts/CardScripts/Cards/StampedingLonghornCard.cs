using UnityEngine;
using System.Collections;

public class StampedingLonghornCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Stampeding Longhorn";
        cardRace = Race.Horned_Beast;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 4000;
        cantBeBlockedCondition = (blocker) => { return blocker.cardPower <= 3000; };
    }
}
