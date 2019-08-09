using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.CardScripts.Abilities;

public class GatlingSkyterrorCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Gatling Skyterror";
        cardRace = Race.Armored_Wyvern;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 7;
        cardPower = 7000;
        simpleAbility = SimpleAbility.CanAttackUntapped;
        abilities.Add(new DoubleBreaker());
    }
}
