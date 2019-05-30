using UnityEngine;
using System.Collections;

public class DarkClownCard : Card
{

    void Start()
    {
        cardName = "Dark Clown";
        cardRace = Race.Brain_Jacker;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 6000;
        abilities.Add(new Blocker(this));
        cantAttack = true;
        dieOnWin = true;
    }
}
