using UnityEngine;
using System.Collections;

public class AquaSniperCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Aqua Sniper";
        cardRace = Race.Liquid_People;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 8;
        cardPower = 5000;
        abilities.Add(new OnCallActionChoose((card, player) => { player.RemoveFieldAddHand(card); }, 2, false, false, false));
    }

}
