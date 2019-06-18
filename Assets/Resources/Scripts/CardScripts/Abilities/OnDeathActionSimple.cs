using UnityEngine;
using System.Collections;

//"When this creature would be destroyed, put it into your hand instead" ability
public class OnDeathActionSimple : OnDeathAbility
{
    private System.Action<Card, PlayerScript> onDeathAction { get; set; }

    public OnDeathActionSimple(Card card, System.Action<Card, PlayerScript> action) : base(card) {
        onDeathAction = action;
    }

    public override IEnumerator OnDeathCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer,
        InputController inputController)
    {
        onDeathAction.Invoke(ownerCard, ownerCard.owner);
        yield return null;
    }
}
