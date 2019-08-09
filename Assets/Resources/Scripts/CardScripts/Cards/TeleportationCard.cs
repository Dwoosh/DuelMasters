using UnityEngine;
using System.Collections;

public class TeleportationCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Teleportation";
        cardCiv = Civilization.Water;
        cardCost = 5;
        abilities.Add(new OnCallActionChoose((card, player) => { player.RemoveFieldAddHand(card); }, 2, false, false, false));
    }
}
