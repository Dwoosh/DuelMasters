using UnityEngine;
using System.Collections;

public class StormShellCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Storm Shell";
        cardRace = Race.Colony_Beetle;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 7;
        cardPower = 2000;
        abilities.Add(new OnCallActionChoose((card, owner) => { owner.RemoveFieldAddMana(card); }, 1, true, false, true));
    }
}
