using UnityEngine;
using System.Collections;

public class MoonlightFlashCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Moonlight Flash";
        cardCiv = Civilization.Light;
        cardCost = 4;
        abilities.Add(new OnCallActionChoose(card => { card.Tap(); }, 2, true, false, false));
    }

}
