﻿using UnityEngine;
using System.Collections;
using System.Linq;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class IocantCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Iocant, the Oracle";
        cardRace = Race.Light_Bringer;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 2000;
        abilities.Add(new Blocker(this));
        simpleAbility = SimpleAbility.CantAttackPlayers;
    }

    //while angel command is in battlefield this gets +2000
    void Update()
    {
        BaseUpdate();
        if (owner.field.Any(x => x.cardRace == Race.Angel_Command)) { cardPower = 4000; }
        else cardPower = 2000;
    }

}
