using UnityEngine;
using System.Collections;

public class PoisonuousMushroomCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Poisonuous Mushroom";
        cardRace = Race.Balloon_Mushroom;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 1000;
        abilities.Add(new OnCallChooseHand((card, owner) => { owner.RemoveHandAddMana(card); }));
    }
}
