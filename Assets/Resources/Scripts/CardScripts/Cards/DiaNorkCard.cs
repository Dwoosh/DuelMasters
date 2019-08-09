using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

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
        simpleAbility = SimpleAbility.CantAttackPlayers;
    }
    
}
