using UnityEngine;
using System.Collections;

public class DarkReversalCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Dark Reversal";
        cardCiv = Civilization.Darkness;
        cardCost = 2;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallReturnFromGrave(owner, 1, card => card.cardType == Type.Creature));
    }
}
