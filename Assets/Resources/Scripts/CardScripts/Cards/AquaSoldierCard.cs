using UnityEngine;
using System.Collections;

public class AquaSoldierCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Aqua Soldier";
        cardRace = Race.Liquid_People;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 1000;
        abilities.Add(new OnDeathActionSimple(this, (card, owner) => { owner.RemoveGraveyardAddHand(card); }));
    }
}
