using UnityEngine;
using System.Collections;

public class MagmaGazerCard : SpellCard
{
    private DoubleBreaker addedBreaker { get; set; }

    void Start()
    {
        SpellStart();
        cardName = "Magma Gazer";
        cardCiv = Civilization.Fire;
        cardCost = 3;
        addedBreaker = new DoubleBreaker();
        abilities.Add(new OnCallChooseUntilTurnEnd(card => { card.powerAttacker += 4000; card.abilities.Add(addedBreaker); },
            card => { card.powerAttacker -= 4000; card.abilities.Remove(addedBreaker); }, 1, true, false));
    }
    
}
