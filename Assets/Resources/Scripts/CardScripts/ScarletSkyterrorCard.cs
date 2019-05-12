using UnityEngine;
using System.Collections;

//TODO: finish ability
public class ScarletSkyterrorCard : Card
{
    public OnCallDestroyOnField onCallDestroyOnField;

    void Start()
    {
        BaseStart();
        cardName = "Skarlet Skyterror";
        cardRace = Enums.Race.Armored_Wyvern;
        cardCiv = Enums.Civilization.Fire;
        cardType = Enums.Type.Creature;
        manaCost = 8;
        cardPower = 3000;
        onCallDestroyOnField = new OnCallDestroyOnField(x => { return x.GetType().GetProperty("blocker") != null; });
    }

    void Update()
    {
        BaseUpdate();
    }

    public override void OnCall()
    {
        base.OnCall();
        onCallDestroyOnField.SubscribeToEvent();
    }

    public override void OnAfterCall()
    {
        onCallDestroyOnField.UnsubscribeToEvent();
    }

    public override void OnAfterDeath()
    {
        onCallDestroyOnField.UnsubscribeToEvent();
    }
}
