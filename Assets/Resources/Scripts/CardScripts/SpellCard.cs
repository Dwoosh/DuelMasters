using UnityEngine;
using System.Collections;

public class SpellCard : Card
{

    protected void SpellStart()
    {
        BaseStart();
        cardRace = Race.None;
        cardType = Type.Spell;
        cardPower = 0;
    }

    protected void SpellUpdate()
    {
        BaseUpdate();
    }

    //below implementation allows to add ability as item in list or override method spellability
    public override void OnCall()
    {
        SpellAbility();
        base.OnCall();
    }

    public override void OnAfterCall()
    {
        owner.RemoveFieldAddGraveyard(this);
    }

    public virtual void SpellAbility() { }

}
