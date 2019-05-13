using UnityEngine;
using System.Collections;

public class AstrocometDragonCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Astrocomet Dragon";
        cardRace = Enums.Race.Armored_Dragon;
        cardCiv = Enums.Civilization.Fire;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 6000;
        powerAttacker = 4000;
        abilities.Add(new DoubleBreaker());
    }
    
}
