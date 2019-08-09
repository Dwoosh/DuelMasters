using UnityEngine;
using System.Collections;

public class KingRippedHideCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "King Ripped-Hide";
        cardRace = Race.Leviathan;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 7;
        cardPower = 5000;
        abilities.Add(new OnCallActionSingle(() => { owner.DrawCard(); }, 2));
    }
}
