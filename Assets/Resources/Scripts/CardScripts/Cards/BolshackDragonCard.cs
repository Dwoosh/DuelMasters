using UnityEngine;
using System.Collections;
using System.Linq;

public class BolshackDragonCard : Card
{
    void Start()
    {
        BaseStart();
        cardName = "Bolshack Dragon";
        cardRace = Race.Armored_Dragon;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 6;
        cardPower = 6000;
        abilities.Add(new DoubleBreaker());
    }

    //While attacking, this creature gets +1000 power for each fire card in your graveyard
    void Update()
    {
        BaseUpdate();
        int graveyardFireCount = owner.graveyard.cards.Count(card => card.cardCiv == Civilization.Fire);
        powerAttacker = 1000 * graveyardFireCount;
    }
}
