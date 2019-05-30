using UnityEngine;
using System.Collections;

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
        cantAttackPlayers = true;
    }
    
}
