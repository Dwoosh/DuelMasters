using UnityEngine;
using System.Collections;

public class AuraBlastCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Aura Blast";
        cardCiv = Civilization.Nature;
        cardCost = 4;
        abilities.Add(new OnCallAllUntilTurnEnd(card => {return true; }, (card, owner) => { card.powerAttacker += 2000; }, 
            card => { card.powerAttacker -= 2000; }, true, false));
    }
}
