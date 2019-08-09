using UnityEngine;
using System.Collections;

public class BrainSerumCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Brain Serum";
        cardCiv = Civilization.Water;
        cardCost = 4;
        abilities.Add(new ShieldTrigger(this));
        abilities.Add(new OnCallActionSingle(() => { owner.DrawCard(); }, 2));
    }

}
