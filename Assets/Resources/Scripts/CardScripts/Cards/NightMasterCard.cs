using UnityEngine;
using System.Collections;

public class NightMasterCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Night Master, Shadow of Decay";
        cardRace = Race.Ghost;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 6;
        cardPower = 3000;
        abilities.Add(new Blocker(this));
    }

}
