using UnityEngine;
using System.Collections;

public class TropicoCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Tropico";
        cardRace = Race.Cyber_Lord;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 3000;
    }

    void Update()
    {
        cantBeBlockedCondition = (blocker) => { return owner.GetFieldCount() - 1 >= 2; };
    }
}
