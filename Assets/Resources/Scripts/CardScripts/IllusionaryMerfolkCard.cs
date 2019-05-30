using UnityEngine;
using System.Collections;
using System.Linq;

public class IllusionaryMerfolkCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Illusionary Merfolk";
        cardRace = Race.Gel_Fish;
        cardCiv = Civilization.Water;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 4000;
        abilities.Add(new OnCallActionSingle(() => owner.DrawCard(), 3, 
            () => { return owner.field.Any(card => card.cardRace == Race.Cyber_Lord); }));
    }
}
