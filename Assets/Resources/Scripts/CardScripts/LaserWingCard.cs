using UnityEngine;
using System.Collections;

public class LaserWingCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Laser Wing";
        cardCiv = Civilization.Light;
        cardCost = 5;
        abilities.Add(new OnCallActionChoose(card => { card.cantBeBlocked = true; }, 2, false, true, false));
    }

    public override void SpellAbility()
    {
        EventManager.OnEndTurnEvent += UndoAbilityOnEnd;
    }

    private void UndoAbilityOnEnd()
    {
        OnCallActionChoose ability = (OnCallActionChoose) abilities[0];
        Card firstCard = ability.chosenCards[0];
        Card secondCard = ability.chosenCards[1];
        if(firstCard != null) { firstCard.cantBeBlocked = false; }
        if(secondCard != null) { secondCard.cantBeBlocked = false; }
        EventManager.OnEndTurnEvent -= UndoAbilityOnEnd; //unsubscribe itself after its done
    }
}
