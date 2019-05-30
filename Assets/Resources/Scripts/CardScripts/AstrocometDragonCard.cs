using UnityEngine;
using System.Collections;

public class AstrocometDragonCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Astrocomet Dragon";
        cardRace = Race.Armored_Dragon;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 7;
        cardPower = 6000;
        powerAttacker = 4000;
        abilities.Add(new DoubleBreaker());
    }
    
}
