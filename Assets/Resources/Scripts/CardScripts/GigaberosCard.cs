using UnityEngine;
using System.Collections;

public class GigaberosCard : Card
{

    void Start()
    {
        cardName = "Gigaberos";
        cardRace = Race.Chimera;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 8000;
        abilities.Add(new DoubleBreaker());
        abilities.Add(new OnCallActionChooseThisOr(this, 2, (card, owner) => { owner.RemoveFieldAddGraveyard(card); }));
    }
}
