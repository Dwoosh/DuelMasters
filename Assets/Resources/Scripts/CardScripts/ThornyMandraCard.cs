using UnityEngine;
using System.Collections;

public class ThornyMandraCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Thorny Mandra";
        cardRace = Race.Tree_Folk;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 4000;
        abilities.Add(new OnCallChooseGraveyard((card, owner) => { owner.RemoveGraveyardAddMana(card); }));
    }
}
