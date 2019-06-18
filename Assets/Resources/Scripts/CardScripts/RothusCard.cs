using UnityEngine;
using System.Collections;

public class RothusCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Rothus, the Traveler";
        cardRace = Race.Armorloid;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 4000;
        abilities.Add(new OnCallActionChoose((card, owner) => { owner.RemoveFieldAddGraveyard(card); }, 
            1, false, true, true));
        abilities.Add(new OnCallActionChoose((card, owner) => { owner.RemoveFieldAddGraveyard(card); },
            1, true, false, true));
    }
}
