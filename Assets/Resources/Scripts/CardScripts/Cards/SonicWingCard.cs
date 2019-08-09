using UnityEngine;
using System.Collections;

public class SonicWingCard : SpellCard
{

    void Start()
    {
        SpellStart();
        cardName = "Sonic Wing";
        cardCiv = Civilization.Light;
        cardCost = 5;
        abilities.Add(new OnCallActionChoose(card => { card.cantBeBlockedCondition = (blocker) => { return true; }; ; }, 1, false, true, false));
    }

    public override void SpellAbility()
    {
        EventManager.OnEndTurnEvent += UndoAbilityOnEnd;
    }

    private void UndoAbilityOnEnd()
    {
        OnCallActionChoose ability = (OnCallActionChoose)abilities[0];
        Card card = ability.chosenCards[0];
        if (card != null) { card.cantBeBlockedCondition = (blocker) => { return false; }; }
        EventManager.OnEndTurnEvent -= UndoAbilityOnEnd; //unsubscribe itself after its done
    }
}
