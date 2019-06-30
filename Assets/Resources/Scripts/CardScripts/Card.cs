using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //basic fields
    public string cardName { get; set; }
    public Race cardRace { get; set; }
    public Civilization cardCiv { get; set; }
    public Type cardType { get; set; }
    public int cardCost { get; set; }
    public int cardPower { get; set; }

    public List<Ability> abilities { get; set; }

    //game logic fields
    public bool isManaTapped = false;
    public bool isTapped = false;
    public int costPaid = 0;

    //simple ability fields
    public int powerAttacker = 0;
    public System.Func<Card, bool> cantBeBlockedCondition = (blocker) => { return false; };
    public bool cantAttackPlayers = false;
    public bool cantAttack = false;
    public bool dieOnWin = false;
    public bool slayer = false;
    public bool attacksEachTurn = false;
    public bool vulnerableUntapped = false;
    public bool canAttackUntapped = false;

    //technical fields
    public PlayerScript owner;
    private Material material;
    bool isOutlined;


    protected void BaseStart()
    {
        isOutlined = false;
        material = GetComponent<Renderer>().material;
        material.SetFloat("_FirstOutlineWidth", 0.0f);
        abilities = new List<Ability>();
    }

    protected void BaseUpdate()
    {

    }

    public virtual void OnCall() {
        costPaid = 0;
        abilities.ForEach(x => x.OnCall());
    }

    public virtual void OnAfterCall() {
        abilities.ForEach(x => x.OnAfterCall());
    }

    public virtual void OnShieldAttack() {
        abilities.ForEach(x => x.OnShieldAttack());
    }

    public virtual void OnAfterShieldAttack() {
        abilities.ForEach(x => x.OnAfterShieldAttack());
    }

    public virtual void OnShieldDestroyed()
    {
        abilities.ForEach(x => x.OnShieldDestroyed());
    }

    public virtual void OnAfterShieldDestroyed()
    {
        abilities.ForEach(x => x.OnAfterShieldDestroyed());
    }

    public virtual void OnDeath() {
        abilities.ForEach(x => x.OnDeath());
    }

    public virtual void OnAfterDeath() {
        abilities.ForEach(x => x.OnAfterDeath());
    }

    public virtual void SubscribeToTurnEvents() {
        abilities.ForEach(x => x.SubscribeToTurnEvents());
    }

    public virtual void UnsubscribeToTurnEvents() {
        abilities.ForEach(x => x.UnsubscribeToTurnEvents());
    }

    public virtual void SubscribeToOddTurnEvents() {
        abilities.ForEach(x => x.SubscribeToOddTurnEvents());
    }

    public virtual void UnsubscribeToOddTurnEvents() {
        abilities.ForEach(x => x.UnsubscribeToOddTurnEvents());
    }



    /*
     Main Battle Method
     -1 if attack kills attacker (backfires)
      0 if attack kills both
      1 if attack succeeds
    */
    public int Battle(Card target)
    {
        int result = cardPower + powerAttacker > target.cardPower ? 1 : (cardPower + powerAttacker == target.cardPower ? 0 : -1);
        if(result == 1 && (dieOnWin || target.slayer)) //if attacker wins but has dieOnWin or target has slayer the both die
        {
            result = 0;
            return result;
        }
        if(result == -1 && (target.dieOnWin || slayer)) //if target wins but this has slayer or target has dieOnWin
        {
            result = 0;
            return result;
        }
        return result;
    }

    public void SetOwner(PlayerScript player)
    {
        owner = player;
    }

    public void ManaTap()
    {
        if (!isManaTapped)
        {
            isManaTapped = true;
            transform.eulerAngles = transform.eulerAngles + 90f * Vector3.up;
        }
    }

    public void ManaUntap()
    {
        if (isManaTapped)
        {
            isManaTapped = false;
            transform.eulerAngles = transform.eulerAngles - 90f * Vector3.up;
        }
    }

    public void Tap()
    {
        if (!isTapped)
        {
            isTapped = true;
            transform.eulerAngles = transform.eulerAngles + 90f * Vector3.up;
        }
    }

    public void Untap()
    {
        if (isTapped)
        {
            isTapped = false;
            transform.eulerAngles = transform.eulerAngles - 90f * Vector3.up;
        }
    }

    public bool IsCostPaid()
    {
        return costPaid == cardCost;
    }

    public void ResetOnStart()
    {
        Untap();
        isManaTapped = false;
        costPaid = 0;
    }

    public void Dehighlight()
    {
        if (isOutlined)
        {
            material.SetFloat("_FirstOutlineWidth", 0.0f);
            isOutlined = false;
        }
    }

    public void Highlight()
    {
        if (!isOutlined)
        {
            material.SetFloat("_FirstOutlineWidth", 0.03f);
            isOutlined = true;
        }
    }

}