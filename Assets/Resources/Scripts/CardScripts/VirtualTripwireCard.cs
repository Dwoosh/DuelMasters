using UnityEngine;
using System.Collections;

public class VirtualTripwireCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Virtual Tripwire";
        cardCiv = Civilization.Water;
        cardCost = 3;
        abilities.Add(new OnCallActionChoose(card => card.Tap(), 1, true, false, false));
    }

}
