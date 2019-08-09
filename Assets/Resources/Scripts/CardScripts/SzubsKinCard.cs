using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

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
        simpleAbility = SimpleAbility.CantAttackPlayers;
        abilities.Add(new Blocker(this));
    }
    
}
