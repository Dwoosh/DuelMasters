using UnityEngine;
using System.Collections;

public class ArtisanPicoraCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Artisan Picora";
        cardRace = Race.Machine_Eater;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 1;
        cardPower = 2000;
        abilities.Add(new OnCallBurnMana(1));
    }
}
