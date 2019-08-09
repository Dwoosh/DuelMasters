using UnityEngine;
using System.Collections;

public class CoilingVinesCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Coiling Vines";
        cardRace = Race.Tree_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 3000;
        abilities.Add(new OnDeathActionSimple(this, (card, owner) => { owner.RemoveGraveyardAddMana(card); }));
    }
}
