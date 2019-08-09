using UnityEngine;
using System.Collections;

public class DeathSmokeCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Death Smoke";
        cardCiv = Civilization.Darkness;
        cardCost = 4;
        abilities.Add(new OnCallActionChoose((card, owner) => { owner.RemoveFieldAddGraveyard(card); }, 
            1, true, false, true, card => { return !card.isTapped; }));
    }
}
