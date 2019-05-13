using UnityEngine;
using System.Collections;

public class GranGureCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Gran Gure, Space Guardian";
        cardRace = Enums.Race.Guardian;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 6;
        cardPower = 9000;
        abilities.Add(new Blocker(this));
        cantAttackPlayers = true;
    }
    
}
