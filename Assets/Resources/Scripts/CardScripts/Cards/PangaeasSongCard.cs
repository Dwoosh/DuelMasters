using UnityEngine;
using System.Collections;

public class PangaeasSongCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Pangaea's Song";
        cardCiv = Civilization.Nature;
        cardCost = 1;
        abilities.Add(new OnCallActionChoose((card, owner) => { owner.RemoveFieldAddMana(card); }, 1, false, true, false));
    }
}
