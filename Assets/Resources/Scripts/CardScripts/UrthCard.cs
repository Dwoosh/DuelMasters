using UnityEngine;
using System.Collections;

public class UrthCard : Card
{

    public DoubleBreaker doubleBreaker;
    public EndTurnUntap endTurnUntap;

    void Start()
    {
        BaseStart();
        cardName = "Urth, Purifying Elemental";
        cardRace = Enums.Race.Angel_Command;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 6;
        cardPower = 6000;
        doubleBreaker = new DoubleBreaker();
        endTurnUntap = new EndTurnUntap(this);
    }

    void Update()
    {
        BaseUpdate();
    }

    public override void SubscribeToTurnEvents()
    {
        endTurnUntap.SubscribeToEvent();
    }

    public override void UnsubscribeToTurnEvents()
    {
        endTurnUntap.UnsubscribeToEvent();
    }

    public override void OnCall()
    {
        base.OnCall();
        endTurnUntap.SubscribeToEvent();
    }

    public override void OnShieldAttack()
    {
        doubleBreaker.SubscribeToEvent();
    }

    public override void OnAfterShieldAttack()
    {
        doubleBreaker.UnsubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        doubleBreaker.UnsubscribeToEvent();
        endTurnUntap.UnsubscribeToEvent();
    }

}
