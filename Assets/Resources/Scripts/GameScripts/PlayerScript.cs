using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public ShieldZone shieldZone = new ShieldZone();
    public ManaZone manaZone = new ManaZone();
    public Graveyard graveyard = new Graveyard();
    public Battlefield battlefield;

    public bool isPlayerOne;

    private const float cardSizeX = 2f;
    private const float cardSizeY = 0.1f;
    private const float cardSizeZ = 3f;

    void Start()
    {
        FillDeck();
        if (name == "PlayerOne")
        {
            isPlayerOne = true;
        }
        else
        {
            isPlayerOne = false;
            RotateDeck();
        }
        SetUpShields();
        DrawCard(5);
        SetAllPositions();
    }

    public void FillDeck()
    {
        for (int i = 0; i < 40; ++i)
        {
            deck.Add(Instantiate(Resources.Load<Card>("Prefabs/IereCard")));
        }
    }

    public void SetUpShields()
    {
        for (int i = 0; i < 5; ++i)
        {
            var card = deck[0];
            deck.RemoveAt(0);
            shieldZone.AddShield(card);
        }
    }

    public void DrawCard(int count = 1)
    {
        if (count < 1)
        {
            return;
        }
        for (int i = 0; i < count; ++i)
        {
            var card = deck[0];
            deck.RemoveAt(0);
            hand.Add(card);
        }
    }

    public Card GetCardFromList(ref List<Card> cards, int index)
    {
        var card = cards[index];
        cards.RemoveAt(index);
        return card;
    }

    public void AddCardToList(ref List<Card> cards, Card card)
    {
        cards.Add(card);
    }

    public void SetAllPositions()
    {
        SetDeckPositions();
        SetHandPositions();
        shieldZone.SetPositions(isPlayerOne);
        manaZone.SetPositions(isPlayerOne);
        graveyard.SetPositions(isPlayerOne);
    }

    public void SetHandPositions()
    {
        var cnt = hand.Count;
        for (int i = 0; i < cnt; ++i)
        {
            if (isPlayerOne)
            {
                hand[i].transform.position = new Vector3(173f + cardSizeX + i * 5f, 155f, 127f + cardSizeZ);
            }
            else
            {
                hand[i].transform.position = new Vector3(239f - cardSizeX - i * 5f, 155f, 173f - cardSizeZ);
            }
        }
    }

    public void SetDeckPositions()
    {
        var cnt = deck.Count;
        for (int i = cnt - 1; i > 0; --i)
        {
            if (isPlayerOne)
            {
                deck[i].transform.position = new Vector3(218f, 155f + i * cardSizeY, 138f);
            }
            else
            {
                deck[i].transform.position = new Vector3(194f, 155f + i * cardSizeY, 162f);
            }
        }
    }

    private void RotateDeck()
    {
        var cnt = deck.Count;
        for (int i = 0; i < cnt; ++i)
        {
            deck[i].transform.eulerAngles = deck[i].transform.eulerAngles + 180f * Vector3.up;
        }
    }

}