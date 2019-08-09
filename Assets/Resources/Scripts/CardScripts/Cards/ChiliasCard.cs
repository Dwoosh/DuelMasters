using UnityEngine;
using System.Collections;

public class ChiliasCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Chilias, the Oracle";
        cardRace = Race.Light_Bringer;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 2500;
        abilities.Add(new OnDeathActionSimple(this, (card, owner) => { owner.RemoveGraveyardAddHand(card); }));
    }
    
}
