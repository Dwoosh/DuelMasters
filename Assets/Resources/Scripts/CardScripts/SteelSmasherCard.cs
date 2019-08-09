using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class SteelSmasherCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Steel Smasher";
        cardRace = Race.Beast_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 3000;
        simpleAbility = SimpleAbility.CantAttackPlayers;
    }
}
