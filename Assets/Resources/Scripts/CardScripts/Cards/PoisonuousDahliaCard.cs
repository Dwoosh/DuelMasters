using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class PoisonuousDahliaCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Poisonuous Dahlia";
        cardRace = Race.Tree_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 5000;
        simpleAbility = SimpleAbility.CantAttackPlayers;
    }
}
