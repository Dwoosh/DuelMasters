using UnityEngine;
using System.Collections;

public class VampireSilphyCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Vampire Silphy";
        cardRace = Race.Dark_Lord;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 8;
        cardPower = 4000;
        abilities.Add(new OnCallActionAll(card => { return card.cardPower <= 3000; }, 
            (card, owner) => { owner.RemoveFieldAddGraveyard(card); }, true, true));
    }
}
