using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class BoneSpiderCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Bone Spider";
        cardRace = Race.Living_Dead;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 5000;
        simpleAbility = SimpleAbility.DieOnWin;
    }
}
