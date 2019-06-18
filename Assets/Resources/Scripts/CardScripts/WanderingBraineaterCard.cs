using UnityEngine;
using System.Collections;

public class WanderingBraineaterCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Wandering Braineater";
        cardRace = Race.Living_Dead;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 2000;
        abilities.Add(new Blocker(this));
        cantAttack = true;
    }
}
