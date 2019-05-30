using UnityEngine;
using System.Collections;
using System.Linq;

//TODO: finish ability
public class ScarletSkyterrorCard : Card
{
    void Start()
    {
        BaseStart();
        cardName = "Skarlet Skyterror";
        cardRace = Race.Armored_Wyvern;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 8;
        cardPower = 3000;
        abilities.Add(new OnCallActionAll(card => card.abilities.Any(i => i.GetType() == typeof(Blocker)),
                                         (card, player) => { player.RemoveFieldAddGraveyard(card); }, false));
    }
    
}
