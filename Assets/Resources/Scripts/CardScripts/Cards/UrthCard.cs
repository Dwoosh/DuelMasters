using UnityEngine;
using System.Collections;

public class UrthCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Urth, Purifying Elemental";
        cardRace = Race.Angel_Command;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 6;
        cardPower = 6000;
        abilities.Add(new DoubleBreaker());
        abilities.Add(new EndTurnUntap(this, false));
    }
    
}
