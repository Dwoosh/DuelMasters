using UnityEngine;
using System.Collections;

public class PoisonuousDahliaCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Poisonuous Dahlia";
        cardRace = Race.Tree_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 5000;
        cantAttackPlayers = true;
    }
}
