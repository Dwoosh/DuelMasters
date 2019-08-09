using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class DarkClownCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Dark Clown";
        cardRace = Race.Brain_Jacker;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 6000;
        abilities.Add(new Blocker(this));
        simpleAbility = SimpleAbility.CantAttack | SimpleAbility.DieOnWin;
    }
}
