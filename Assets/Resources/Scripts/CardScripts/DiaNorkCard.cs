using UnityEngine;
using System.Collections;

public class DiaNorkCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Dia Nork, Moonlight Guardian";
        cardRace = Race.Guardian;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 5000;
        abilities.Add(new Blocker(this));
        cantAttackPlayers = true;
    }
    
}
