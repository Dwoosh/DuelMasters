using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //basic fields
    public string cardName { get; set; }
    public Enums.Race cardRace { get; set; }
    public Enums.Civilization cardCiv { get; set; }
    public Enums.Type cardType { get; set; }
    public int manaCost { get; set; }
    public int cardPower { get; set; }

    public List<Ability> abilities { get; set; }

    //game logic fields
    public bool isManaTapped = false;
    public bool isTapped = false;
    public int costPaid = 0;

    //simple ability fields
    public bool cantBeBlocked = false;
    public int powerAttacker = 0;
    public bool cantAttackPlayers = false;

    //technical fields
    public PlayerScript owner;
    public Material normalMat;
    public Material outlinedMat;
    Renderer rend;
    bool isOutlined;


    protected void BaseStart()
    {
        isOutlined = false;
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = normalMat;
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
        return cardPower + powerAttacker > target.cardPower ? 1 : (cardPower + powerAttacker == target.cardPower ? 0 : -1); 
    }

    public void AddOwner(PlayerScript player)
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
        return costPaid == manaCost;
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
            rend.sharedMaterial = normalMat;
            isOutlined = false;
        }
    }

    public void Highlight()
    {
        if (!isOutlined)
        {
            rend.sharedMaterial = outlinedMat;
            isOutlined = true;
        }
    }

}