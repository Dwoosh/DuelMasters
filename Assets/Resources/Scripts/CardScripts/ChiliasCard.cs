using UnityEngine;
using System.Collections;

public class ChiliasCard : Card
{

    public OnDeathReturnToHand onDeathReturnToHand;

    void Start()
    {
        BaseStart();
        cardName = "Chilias, the Oracle";
        cardRace = Enums.Race.Light_Bringer;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 4;
        cardPower = 2500;
        onDeathReturnToHand = new OnDeathReturnToHand(this);
    }

    void Update()
    {
        BaseUpdate();
    }

    public override void OnDeath()
    {
        onDeathReturnToHand.SubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        onDeathReturnToHand.UnsubscribeToEvent();
    }

}
