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
        cardRace = Enums.Race.Armored_Wyvern;
        cardCiv = Enums.Civilization.Fire;
        cardType = Enums.Type.Creature;
        manaCost = 8;
        cardPower = 3000;
        abilities.Add(new OnCallDestroyOnField(x => x.abilities.Any(i => i.GetType() == typeof(Blocker))));
    }
    
}
