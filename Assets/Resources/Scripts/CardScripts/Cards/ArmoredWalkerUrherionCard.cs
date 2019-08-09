using UnityEngine;
using System.Collections;
using System.Linq;

//TODO: take ref to this human card and reset powerattacker only if this ref goes to null? 
public class ArmoredWalkerUrherionCard : Card
{
    void Start()
    {
        BaseStart();
        cardName = "Armored Walker Urherion";
        cardRace = Race.Armorloid;
        cardCiv = Civilization.Fire;
        cardType = Type.Creature;
        cardCost = 4;
        cardPower = 2000;
    }

    //while human is in battlefield this gets +2000 power attacker
    void Update()
    {
        BaseUpdate();
        if (owner.field.Any(x => x.cardRace == Race.Human)) { powerAttacker = 2000; }
        else powerAttacker = 0;
    }

}
