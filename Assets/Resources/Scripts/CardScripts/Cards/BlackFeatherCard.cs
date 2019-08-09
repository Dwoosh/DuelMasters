using UnityEngine;
using System.Collections;

public class BlackFeatherCard : Card
{
    
    void Start()
    {
        BaseStart();
        cardName = "Black Feather, Shadow of Rage";
        cardRace = Race.Ghost;
        cardCiv = Civilization.Darkness;
        cardType = Type.Creature;
        cardCost = 1;
        cardPower = 3000;
        abilities.Add(new OnCallActionChoose((card, player) => { player.RemoveFieldAddGraveyard(card); }, 1, false, true, true));
    }
    
}
