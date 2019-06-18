using UnityEngine;
using System.Collections;

public class NomadHeroGigioCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Nomad Hero Gigio";
        cardRace = Race.Machine_Eater;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 3000;
        canAttackUntapped = true;
    }
}
