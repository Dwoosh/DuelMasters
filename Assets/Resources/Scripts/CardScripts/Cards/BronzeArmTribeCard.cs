using UnityEngine;
using System.Collections;

public class BronzeArmTribeCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Bronze-Arm Tribe";
        cardRace = Race.Beast_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 1000;
        abilities.Add(new OnCallActionSingle(() => { owner.RemoveDeckAddMana(); }));
    }

}
