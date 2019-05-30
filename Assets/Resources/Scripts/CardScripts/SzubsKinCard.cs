using UnityEngine;
using System.Collections;

public class SzubsKinCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Szubs Kin, Twilight Guardian";
        cardRace = Race.Guardian;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 6000;
        cantAttackPlayers = true;
        abilities.Add(new Blocker(this));
    }
    
}
