using UnityEngine;
using System.Collections;

public class SpiralGateCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Spiral Gate";
        cardCiv = Civilization.Water;
        cardCost = 2;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallActionChoose((card, player) => { player.RemoveFieldAddHand(card); }, 1, false, false, false));
    }
}
