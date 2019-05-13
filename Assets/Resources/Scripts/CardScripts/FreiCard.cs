using UnityEngine;
using System.Collections;

public class FreiCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Frei, Vizier of Air";
        cardRace = Enums.Race.Initiate;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 4;
        cardPower = 3000;
        abilities.Add(new EndTurnUntap(this));
    }
    
}
