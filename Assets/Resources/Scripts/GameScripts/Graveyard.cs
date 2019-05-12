using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard
{

    public List<Card> cards;

    private const float cardSizeX = 2f;
    private const float cardSizeY = 0.1f;
    private const float cardSizeZ = 3f;

    public Graveyard()
    {
        cards = new List<Card>();
    }

    public void AddCardToGraveyard(Card card)
    {
        cards.Add(card);
    }

    public void RemoveCardFromGraveyard(Card card)
    {
        cards.Remove(card);
    }

    public void SetPositions(bool isPlayerOne)
    {
        var cnt = cards.Count;
        for (int i = 0; i < cnt; ++i)
        {
            if (isPlayerOne)
            {
                cards[i].transform.position = new Vector3(227f, 155f + i * cardSizeY, 138f);
            }
            else
            {
                cards[i].transform.position = new Vector3(185f, 155f + i * cardSizeY, 162f);
            }
        }
    }

}