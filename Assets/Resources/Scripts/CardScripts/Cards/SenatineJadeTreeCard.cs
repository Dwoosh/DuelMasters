using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class SenatineJadeTreeCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Senatine Jade Tree";
        cardRace = Race.Starlight_Tree;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 4000;
        simpleAbility = SimpleAbility.CantAttackPlayers;
        abilities.Add(new Blocker(this));
    }
}
