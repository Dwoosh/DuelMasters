using UnityEngine;
using System.Collections;

public class ChaosStrikeCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Chaos Strike";
        cardCiv = Civilization.Fire;
        cardCost = 2;
        abilities.Add(new OnCallChooseUntilTurnEnd(card => card.vulnerableUntapped = true,
            card => card.vulnerableUntapped = false, 1, false, true));
    }
    
}
