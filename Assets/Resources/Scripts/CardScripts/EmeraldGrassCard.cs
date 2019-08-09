using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class EmeraldGrassCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Emerald Grass";
        cardRace = Race.Starlight_Tree;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 3000;
        abilities.Add(new Blocker(this));
        simpleAbility = SimpleAbility.CantAttackPlayers;
    }
    
}
