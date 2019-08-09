using UnityEngine;
using System.Collections;

public class RedEyeScorpionCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Red-Eye Scorpion";
        cardRace = Race.Giant_Insect;
        cardCiv = Civilization.Nature;
        cardType = Type.Creature;
        cardCost = 5;
        cardPower = 4000;
        abilities.Add(new OnDeathActionSimple(this, (card, owner) => { owner.RemoveGraveyardAddMana(card); }));
    }
}
