using UnityEngine;
using System.Collections;

public class ImmortalBaronCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Immortal Baron, Vorg";
        cardRace = Race.Human;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 2000;
    }
    
}
