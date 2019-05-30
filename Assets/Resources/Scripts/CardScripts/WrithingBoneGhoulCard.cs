using UnityEngine;
using System.Collections;

public class WrithingBoneGhoulCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Writhing Bone Ghoul";
        cardRace = Race.Living_Dead;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 2;
        cardPower = 2000;
    }
}
