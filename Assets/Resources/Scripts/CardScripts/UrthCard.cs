using UnityEngine;
using System.Collections;

public class UrthCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Urth, Purifying Elemental";
        cardRace = Enums.Race.Angel_Command;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 6;
        cardPower = 6000;
        abilities.Add(new DoubleBreaker());
        abilities.Add(new EndTurnUntap(this));
    }
    
}
