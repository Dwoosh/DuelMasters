using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class BloodySquitoCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Bloody Squito";
        cardRace = Race.Brain_Jacker;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 4000;
        abilities.Add(new Blocker(this));
        simpleAbility = SimpleAbility.CantAttack | SimpleAbility.DieOnWin;
    }
}
