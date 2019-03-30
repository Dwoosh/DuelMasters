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

    public Card RemoveCardfromBattlefield(int index, bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            if (playerOneCards.Count - 1 < index)
            {
                return null;
            }
            var card = playerOneCards[index];
            playerOneCards.RemoveAt(index);
            return card;
        }
        else
        {
            if (playerTwoCards.Count - 1 < index)
            {
                return null;
            }
            var card = playerTwoCards[index];
            playerTwoCards.RemoveAt(index);
            return card;
        }
    }

    public bool IsCurrentPlayerFieldFull()
    {
        return currentPlayerCards.Count != 0;
    }

    public bool IsOtherPlayerFieldFull()
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