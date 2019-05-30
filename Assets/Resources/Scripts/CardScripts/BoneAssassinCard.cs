using UnityEngine;
using System.Collections;

public class BoneAssassinCard : Card
{
    
    void Start()
    {
        cardName = "Bone Assassin, the Ripper";
        cardRace = Race.Living_Dead;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 2000;
        slayer = true;
    }
}
