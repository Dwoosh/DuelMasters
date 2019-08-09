using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class RubyGrassCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Ruby Grass";
        cardRace = Race.Starlight_Tree;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 3000;
        simpleAbility = SimpleAbility.CantAttackPlayers;
        abilities.Add(new Blocker(this));
        abilities.Add(new EndTurnUntap(this, false));
    }
}
