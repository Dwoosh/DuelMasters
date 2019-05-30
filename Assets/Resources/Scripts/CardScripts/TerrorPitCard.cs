using UnityEngine;
using System.Collections;

public class TerrorPitCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Terror Pit";
        cardCiv = Civilization.Darkness;
        cardCost = 6;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallActionChoose((card, owner) => owner.RemoveFieldAddGraveyard(card), 1, true, false, true));
    }
}
