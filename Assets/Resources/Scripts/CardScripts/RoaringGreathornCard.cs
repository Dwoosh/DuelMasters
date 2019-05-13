using UnityEngine;
using System.Collections;

public class RoaringGreathornCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Roaring Great-Horn";
        cardRace = Enums.Race.Horned_Beast;
        cardCiv = Enums.Civilization.Nature;
        cardType = Enums.Type.Creature;
        manaCost = 7;
        cardPower = 8000;
        powerAttacker = 2000;
        abilities.Add(new DoubleBreaker());
    }
    
}
