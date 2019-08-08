using UnityEngine;
using System.Collections;

public class ForestHornetCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Forest Hornet";
        cardRace = Race.Giant_Insect;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 4000;
    }
}
