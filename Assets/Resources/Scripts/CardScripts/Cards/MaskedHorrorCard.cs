using UnityEngine;
using System.Collections;

public class MaskedHorrorCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Masked Horror, Shadow of Scorn";
        cardRace = Race.Ghost;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 1000;
        abilities.Add(new OnCallDiscardRandom(1));
    }

}
