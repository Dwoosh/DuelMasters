using UnityEngine;
using System.Collections;

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
        canAttackUntapped = true;
        abilities.Add(new DoubleBreaker());
    }
}
