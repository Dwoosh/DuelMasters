using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

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
        simpleAbility = SimpleAbility.CantAttack;
    }
}
