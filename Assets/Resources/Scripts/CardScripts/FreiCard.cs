using UnityEngine;
using System.Collections;

public class FreiCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Frei, Vizier of Air";
        cardRace = Race.Initiate;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 3000;
        abilities.Add(new EndTurnUntap(this, false));
    }
    
}
