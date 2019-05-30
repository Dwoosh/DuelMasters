using UnityEngine;
using System.Collections;

public class RevolverFishCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Revolver Fish";
        cardRace = Race.Gel_Fish;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 5000;
        abilities.Add(new Blocker(this));
        cantAttack = true;
    }
}
