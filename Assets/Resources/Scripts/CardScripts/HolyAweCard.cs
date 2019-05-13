using UnityEngine;
using System.Collections;

public class HolyAweCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Holy Awe";
        cardCiv = Enums.Civilization.Light;
        manaCost = 6;
    }
    
    public override void SpellAbility()
    {
        owner.battlefield.otherPlayerCards.ForEach(x => x.Tap());
    }

}
