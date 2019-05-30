using UnityEngine;
using System.Collections;

public class LaUraGigaCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "La Ura Giga, Sky Guardian";
        cardRace = Race.Guardian;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 1;
        cardPower = 2000;
        abilities.Add(new Blocker(this));
        cantAttackPlayers = true;
    }

}
