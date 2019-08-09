using UnityEngine;
using System.Collections;

public class GigargonCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Gigargon";
        cardRace = Race.Chimera;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 8;
        cardPower = 3000;
        abilities.Add(new OnCallReturnFromGrave(owner, 2, card => { return card.cardType == Type.Creature; }));
    }
}
