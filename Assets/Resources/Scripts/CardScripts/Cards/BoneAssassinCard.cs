using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class BoneAssassinCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Bone Assassin, the Ripper";
        cardRace = Race.Living_Dead;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 2000;
        simpleAbility = SimpleAbility.Slayer;
    }
}
