using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class HunterFishCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Hunter Fish";
        cardRace = Race.Fish;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 3000;
        simpleAbility = SimpleAbility.CantAttack;
        abilities.Add(new Blocker(this));
    }
}
