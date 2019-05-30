using UnityEngine;
using System.Collections;

public class GigagieleCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Gigagiele";
        cardRace = Race.Chimera;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 3000;
        slayer = true;
    }
}
