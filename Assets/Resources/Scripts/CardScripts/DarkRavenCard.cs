using UnityEngine;
using System.Collections;

public class DarkRavenCard : Card
{

    void Start()
    {
        cardName = "Dark Raven, Shadow of Grief";
        cardRace = Race.Ghost;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 1000;
        abilities.Add(new Blocker(this));
    }

}
