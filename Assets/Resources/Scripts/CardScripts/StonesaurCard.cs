using UnityEngine;
using System.Collections;

public class StonesaurCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Stonesaur";
        cardRace = Race.Rock_Beast;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 4000;
        powerAttacker = 2000;
    }
}
