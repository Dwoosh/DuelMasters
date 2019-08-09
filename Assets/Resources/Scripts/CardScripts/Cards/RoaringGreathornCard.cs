using UnityEngine;
using System.Collections;

public class RoaringGreatHornCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Roaring Great-Horn";
        cardRace = Race.Horned_Beast;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 7;
        cardPower = 8000;
        powerAttacker = 2000;
        abilities.Add(new DoubleBreaker());
    }
    
}
