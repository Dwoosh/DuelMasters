using UnityEngine;
using System.Collections;

public class GranGureCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Gran Gure, Space Guardian";
        cardRace = Race.Guardian;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 6;
        cardPower = 9000;
        abilities.Add(new Blocker(this));
        cantAttackPlayers = true;
    }
    
}
