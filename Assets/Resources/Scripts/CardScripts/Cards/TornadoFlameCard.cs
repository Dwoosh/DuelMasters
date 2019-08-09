using UnityEngine;
using System.Collections;

public class TornadoFlameCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Tornado Flame";
        cardCiv = Civilization.Fire;
        cardCost = 5;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallActionChoose((card, owner) => { owner.RemoveFieldAddGraveyard(card); },
            1, true, false, false, card => card.cardPower <= 4000));
    }
}
