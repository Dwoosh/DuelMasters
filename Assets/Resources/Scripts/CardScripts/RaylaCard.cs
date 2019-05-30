using UnityEngine;
using System.Collections;

public class RaylaCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Rayla, Truth Enforcer";
        cardRace = Race.Berserker;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 6;
        cardPower = 3000;
        abilities.Add(new OnCallSearchDeck(owner, card => { return card.cardType == Type.Spell; }));
    }

}
