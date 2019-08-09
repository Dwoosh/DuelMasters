using UnityEngine;
using System.Collections;

public class TrihornShepherdCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Tri-horn Shepherd";
        cardRace = Race.Horned_Beast;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 5000;
    }
}
