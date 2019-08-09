using UnityEngine;
using System.Collections;

public class UnicornFishCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Unicorn Fish";
        cardRace = Race.Fish;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 1000;
        abilities.Add(new OnCallActionChoose((card, player) => { player.RemoveFieldAddHand(card); }, 2, false, false, false));
    }

}
