using UnityEngine;
using System.Collections;

public class LaUraGigaCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "La Ura Giga, Sky Guardian";
        cardRace = Enums.Race.Guardian;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 1;
        cardPower = 2000;
        abilities.Add(new Blocker(this));
        cantAttackPlayers = true;
    }

}
