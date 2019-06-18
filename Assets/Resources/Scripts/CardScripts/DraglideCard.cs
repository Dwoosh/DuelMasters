using UnityEngine;
using System.Collections;

public class DraglideCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Draglide";
        cardRace = Race.Armored_Wyvern;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 5000;
        attacksEachTurn = true;
    }
}
