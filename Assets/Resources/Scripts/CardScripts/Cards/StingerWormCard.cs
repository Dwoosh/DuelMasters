using UnityEngine;
using System.Collections;

public class StingerWormCard : Card
{
    void Start()
    {
        BaseStart();
        cardName = "Stinger Worms";
        cardRace = Race.Parasite_Worm;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 5000;
        abilities.Add(new OnCallActionChoose((card, owner) => owner.RemoveFieldAddGraveyard(card), 1, false, true, true));
    }
}
