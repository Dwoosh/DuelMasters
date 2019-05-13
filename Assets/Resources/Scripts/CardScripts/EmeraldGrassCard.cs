using UnityEngine;
using System.Collections;

public class EmeraldGrassCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Emerald Grass";
        cardRace = Enums.Race.Starlight_Tree;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 2;
        cardPower = 3000;
        abilities.Add(new Blocker(this));
        cantAttackPlayers = true;
    }
    
}
