using UnityEngine;
using System.Collections;

public class SwampWormCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Swamp Worm";
        cardRace = Race.Parasite_Worm;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 7;
        cardPower = 2000;
        abilities.Add(new OnCallActionChoose((card, owner) => owner.RemoveFieldAddGraveyard(card), 1, true, false, true));
    }
}
