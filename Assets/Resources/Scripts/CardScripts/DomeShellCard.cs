using UnityEngine;
using System.Collections;

public class DomeShellCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Dome Shell";
        cardRace = Race.Colony_Beetle;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 3000;
        powerAttacker = 2000;
    }
}
