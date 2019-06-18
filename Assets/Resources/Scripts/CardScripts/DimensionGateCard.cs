using UnityEngine;
using System.Collections;

public class DimensionGateCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Dimension Gate";
        cardCiv = Civilization.Nature;
        cardCost = 3;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallSearchDeck(owner, card => { return card.cardType == Type.Creature; }));
    }
}
