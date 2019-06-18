using UnityEngine;
using System.Collections;

public class DeadlyFighterBraidClawCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Deadly Fighter Braid Claw";
        cardRace = Race.Dragonoid;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 1;
        cardPower = 1000;
        attacksEachTurn = true;
    }
}
