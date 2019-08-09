using UnityEngine;
using System.Collections;

public class OnslaughterTricepsCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Onslaughter Triceps";
        cardRace = Race.Dragonoid;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 5000;
        abilities.Add(new OnCallActionChoose((card, owner) => { owner.RemoveManaAddGraveyard(card); },
            1, false, true, true));
    }
}
