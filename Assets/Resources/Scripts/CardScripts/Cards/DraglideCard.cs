using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class DraglideCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Draglide";
        cardRace = Race.Armored_Wyvern;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 5000;
        simpleAbility = SimpleAbility.AttacksEachTurn;
    }
}
