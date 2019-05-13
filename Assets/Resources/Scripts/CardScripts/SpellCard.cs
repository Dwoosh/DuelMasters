using UnityEngine;
using System.Collections;

public class SpellCard : Card
{

    protected void SpellStart()
    {
        BaseStart();
        cardRace = Enums.Race.None;
        cardType = Enums.Type.Spell;
        cardPower = 0;
    }

    protected void SpellUpdate()
    {
        BaseUpdate();
    }

    public override void OnCall()
    {
        base.OnCall();
        SpellAbility();
    }

    public override void OnAfterCall()
    {
        owner.RemoveFieldAddGraveyard(this);
    }

    public virtual void SpellAbility() { }

}
