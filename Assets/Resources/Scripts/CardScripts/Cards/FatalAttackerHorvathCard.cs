using UnityEngine;
using System.Collections;
using System.Linq;

public class FatalAttackerHorvathCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Fatal Attacker Horvath";
        cardRace = Race.Human;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 3;
        cardPower = 2000;
    }

    void Update() {
        if(owner.field.Any(card => card.cardRace == Race.Armorloid)) { powerAttacker = 2000; }
        else { powerAttacker = 0; }
    }
    
}
