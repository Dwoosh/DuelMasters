using UnityEngine;
using System.Collections;

public class NaturalSnareCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Natural Snare";
        cardCiv = Civilization.Nature;
        cardCost = 6;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallActionChoose((card, owner) => { owner.RemoveFieldAddMana(card); }, 1, true, false, false));
    }
}
