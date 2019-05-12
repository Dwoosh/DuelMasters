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
    }

    protected void BaseUpdate()
    {

    }

    public virtual void OnCall() { costPaid = 0; }

    public virtual void OnAfterCall() { }

    public virtual void OnShieldAttack() { }

    public virtual void OnAfterShieldAttack() { }

    public virtual void OnDeath() { }

    public virtual void OnAfterDeath() { }

    public virtual void SubscribeToTurnEvents() { }
    public virtual void UnsubscribeToTurnEvents() { }
    public virtual void SubscribeToOddTurnEvents() { }
    public virtual void UnsubscribeToOddTurnEvents() { }



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