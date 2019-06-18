using UnityEngine;
using System.Collections;

public class UltimateForceCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Ultimate Force";
        cardCiv = Civilization.Nature;
        cardCost = 5;
        abilities.Add(new OnCallActionSingle(() => { owner.RemoveDeckAddMana(); }, 2));
    }
}
