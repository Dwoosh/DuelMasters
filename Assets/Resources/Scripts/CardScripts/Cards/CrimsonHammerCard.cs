using UnityEngine;
using System.Collections;

public class CrimsonHammerCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Crimson Hammer";
        cardCiv = Civilization.Fire;
        cardCost = 2;
        abilities.Add(new OnCallActionChoose((card, owner) => owner.RemoveFieldAddGraveyard(card), 
            1, true, false, false, card => card.cardPower <= 2000));
    }
}
