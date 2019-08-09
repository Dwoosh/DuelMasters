using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class ChaosStrikeCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Chaos Strike";
        cardCiv = Civilization.Fire;
        cardCost = 2;
        abilities.Add(new OnCallChooseUntilTurnEnd(card => card.AddSimpleAbility(SimpleAbility.VulnerableUntapped),
            card => card.RemoveSimpleAbility(SimpleAbility.VulnerableUntapped), 1, false, true));
    }
    
}
