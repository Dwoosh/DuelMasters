using UnityEngine;
using System.Collections;

public class AquaHulcusCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Aqua Hulcus";
        cardRace = Race.Liquid_People;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 2000;
        abilities.Add(new OnCallActionSingle(() => owner.DrawCard()));
    }
}
