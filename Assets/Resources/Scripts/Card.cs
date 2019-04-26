using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public string cardName { get; set; }
    public string cardRace { get; set; }
    public Enums.Civilization cardCiv { get; set; }
    public Enums.Type cardType { get; set; }
    public int manaCost { get; set; }
    public int cardPower { get; set; }

    public bool isManaTapped = false;
    public bool isTapped = false;
    public int costPaid = 0;

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

    /*
     Main Battle Method
     -1 if attack kills attacker (backfires)
      0 if attack kills both
      1 if attack succeeds
    */
    public int Battle(Card target)
    {
        return cardPower > target.cardPower ? 1 : (cardPower == target.cardPower ? 0 : -1); 
    }

    public void ManaTap()
    {
        isManaTapped = true;
        transform.eulerAngles = transform.eulerAngles + 90f * Vector3.up;
    }

    public void ManaUntap()
    {
        isManaTapped = false;
        transform.eulerAngles = transform.eulerAngles - 90f * Vector3.up;
    }

    public void Tap()
    {
        isTapped = true;
        transform.eulerAngles = transform.eulerAngles + 90f * Vector3.up;
    }

    public void Untap()
    {
        isTapped = false;
        transform.eulerAngles = transform.eulerAngles - 90f * Vector3.up;
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