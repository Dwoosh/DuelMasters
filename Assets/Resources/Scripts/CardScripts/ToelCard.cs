using UnityEngine;
using System.Collections;

public class ToelCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Toel, Vizier of Hope";
        cardRace = Race.Initiate;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 2000;
        abilities.Add(new EndTurnUntap(this, true));
    }
}
