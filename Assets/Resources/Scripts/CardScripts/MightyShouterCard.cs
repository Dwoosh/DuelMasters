using UnityEngine;
using System.Collections;

public class MightyShouterCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Mighty Shouter";
        cardRace = Race.Beast_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 2000;
        abilities.Add(new OnDeathActionSimple(this, (card, owner) => { owner.RemoveGraveyardAddMana(card); }));
    }
}
