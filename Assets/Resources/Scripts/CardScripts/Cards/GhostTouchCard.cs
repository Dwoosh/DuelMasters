using UnityEngine;
using System.Collections;

public class GhostTouchCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Ghost Touch";
        cardCiv = Civilization.Darkness;
        cardCost = 2;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallDiscardRandom(1));
    }
}
