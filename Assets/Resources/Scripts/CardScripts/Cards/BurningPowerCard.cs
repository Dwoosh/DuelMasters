using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BurningPowerCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Burning Power";
        cardCiv = Civilization.Fire;
        cardCost = 1;
        abilities.Add(new OnCallChooseUntilTurnEnd(card => card.powerAttacker += 2000,
            card => card.powerAttacker -= 2000, 1, true, false));
    }
    
}
