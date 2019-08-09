using UnityEngine;
using System.Collections;

public class SkeletonSoldierCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Skeleton Soldier, the Defiled";
        cardRace = Race.Living_Dead;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 3000;
    }

}
