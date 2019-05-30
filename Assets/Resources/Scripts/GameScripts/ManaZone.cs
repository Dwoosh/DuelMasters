using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: possible removal of mana array
public class ManaZone
{

    public List<Card> cards;
    public int[] mana;

    private const float cardSizeX = 2f;
    private const float cardSizeY = 0.1f;
    private const float cardSizeZ = 3f;

    public ManaZone()
    {
        cards = new List<Card>();
        mana = new int[5] { 0, 0, 0, 0, 0 };
    }

    public void FinalizeManaTap()
    {
        foreach (Card card in cards)
        {
            if (card.isManaTapped)
            {
                card.isTapped = true;
            }
        }
    }

    public void AddCardToManaZone(Card card)
    {
        cards.Add(card);
        mana[(int)card.cardCiv] += 1;
    }

    public Card RemoveCardFromManaZone(int index)
    {
        if (cards.Count - 1 < index)
        {
            return null;
        }
        mana[(int)cards[index].cardCiv] -= 1;
        var card = cards[index];
        cards.RemoveAt(index);
        return card;
    }

    public void SetPositions(bool isPlayerOne)
    {
        var cnt = cards.Count;
        for (int i = 0; i < cnt; ++i)
        {
            int shift = (i - 1) % 3 == 0 ? 1 : 0;
            if (isPlayerOne)
            {
                cards[i].transform.position = new Vector3(231f + cardSizeX + (i % 3) * 2f, 155f + shift * cardSizeY, 149f - cardSizeZ - (i / 3) * 5f);
            }
            else
            {
                cards[i].transform.position = new Vector3(181f - cardSizeX - (i % 3) * 2f, 155f + shift * cardSizeY, 151f + cardSizeZ + (i / 3) * 5f);
            }
        }
    }

}