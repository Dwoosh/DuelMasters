using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{

    public List<Card> playerOneCards = new List<Card>();
    public List<Card> playerTwoCards = new List<Card>();
    public List<Card> currentPlayerCards;
    public List<Card> otherPlayerCards;

    private const float cardSizeX = 2f;
    private const float cardSizeY = 0.1f;
    private const float cardSizeZ = 3f;

    public void Start()
    {
        currentPlayerCards = playerOneCards;
        otherPlayerCards = playerTwoCards;
    }

    public void AddCardToBattlefield(Card card, bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            playerOneCards.Add(card);
        }
        else
        {
            playerTwoCards.Add(card);
        }
    }

    public void RemoveCardfromBattlefield(Card card, bool isPlayerOne)
    {
        int index = isPlayerOne ? playerOneCards.IndexOf(card) : playerTwoCards.IndexOf(card);
        if (index == -1) { return; }
        if (isPlayerOne)
        {
            playerOneCards.RemoveAt(index);
        }
        else
        {
            playerTwoCards.RemoveAt(index);
        }
    }

    public bool IsCurrentPlayerFieldNotEmpty()
    {
        return currentPlayerCards.Count != 0;
    }

    public bool IsOtherPlayerFieldNotEmpty()
    {
        return otherPlayerCards.Count != 0;
    }

    public void SetPositions()
    {
        var cnt = playerOneCards.Count;
        for (int i = 0; i < cnt; ++i)
        {
            playerOneCards[i].transform.position = new Vector3(173f + cardSizeX + i * 4f, 155f, 146f);
        }
        cnt = playerTwoCards.Count;
        for (int i = 0; i < cnt; ++i)
        {
            playerTwoCards[i].transform.position = new Vector3(239f - cardSizeX - i * 5f, 155f, 154f);
        }
    }

    public void SwitchListRef()
    {
        if (currentPlayerCards == playerOneCards)
        {
            currentPlayerCards = playerTwoCards;
            otherPlayerCards = playerOneCards;
        }
        else
        {
            currentPlayerCards = playerOneCards;
            otherPlayerCards = playerTwoCards;
        }
    }

}