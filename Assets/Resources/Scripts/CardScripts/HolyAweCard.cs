using UnityEngine;
using System.Collections;

public class HolyAweCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Holy Awe";
        cardCiv = Civilization.Light;
        cardCost = 6;
        abilities.Add(new ShieldTrigger(this));
    }
    
    public override void SpellAbility()
    {
        owner.battlefield.otherPlayerCards.ForEach(card => card.Tap());
    }

}
