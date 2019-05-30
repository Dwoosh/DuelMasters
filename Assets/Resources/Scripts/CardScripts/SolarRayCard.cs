using UnityEngine;
using System.Collections;

public class SolarRayCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Solar Ray";
        cardCiv = Civilization.Light;
        cardCost = 2;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallActionChoose(card => { card.Tap(); }, 1, true, false, false));
    }

}
