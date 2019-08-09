using UnityEngine;
using System.Collections;

public class CrystalMemoryCard : SpellCard
{

    void Start()
    {
        BaseStart();
        cardName = "Crystal Memory";
        cardCiv = Civilization.Water;
        cardCost = 4;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallSearchDeck(owner, card => { return true; })); //any card
    }
}
