using UnityEngine;
using System.Collections;

public class MieleCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Miele, Vizier of Lightning";
        cardRace = Race.Initiate;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 1000;
        abilities.Add(new OnCallActionChoose(card => { card.Tap(); }, 1, true, false, false));
    }

}
