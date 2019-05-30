using UnityEngine;
using System.Collections;

public class SaucerHeadSharkCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Saucer-Head Shark";
        cardRace = Race.Gel_Fish;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 3000;
        abilities.Add(new OnCallActionAll(card => { return card.cardPower <= 2000; }, (card, player) => { player.RemoveFieldAddHand(card); }, false));
    }
}
