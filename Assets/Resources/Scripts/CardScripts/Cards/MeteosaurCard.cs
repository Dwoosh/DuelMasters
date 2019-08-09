using UnityEngine;
using System.Collections;

public class MeteosaurCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Meteosaur";
        cardRace = Race.Rock_Beast;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 2000;
        abilities.Add(new OnCallActionChoose((card, owner) => { owner.RemoveFieldAddGraveyard(card); },
            1, true, false, false, card => card.cardPower <= 2000));
    }
}
