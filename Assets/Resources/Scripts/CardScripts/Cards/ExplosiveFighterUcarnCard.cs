using UnityEngine;
using System.Collections;

public class ExplosiveFighterUcarnCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Explosive Fighter Ucarn";
        cardRace = Race.Dragonoid;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 9000;
        abilities.Add(new DoubleBreaker());
        abilities.Add(new OnCallActionChoose((card, owner) => owner.RemoveManaAddGraveyard(card), 2, true, false, true));
    }
}
