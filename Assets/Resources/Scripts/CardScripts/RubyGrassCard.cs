using UnityEngine;
using System.Collections;

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
        cantAttackPlayers = true;
        abilities.Add(new Blocker(this));
        abilities.Add(new EndTurnUntap(this, false));
    }
}
