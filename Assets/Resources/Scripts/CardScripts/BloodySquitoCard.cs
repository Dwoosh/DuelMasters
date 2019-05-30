using UnityEngine;
using System.Collections;

public class BloodySquitoCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Bloody Squito";
        cardRace = Race.Brain_Jacker;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 4000;
        abilities.Add(new Blocker(this));
        cantAttack = true;
        dieOnWin = true;
    }
}
