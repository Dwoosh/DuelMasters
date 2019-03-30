using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldZone
{

    public List<Card> shields;

    private const float cardSizeX = 2f;
    private const float cardSizeY = 0.1f;
    private const float cardSizeZ = 3f;

    public ShieldZone()
    {
        shields = new List<Card>();
    }

    public void SetPositions(bool isPlayerOne)
    {
        var cnt = shields.Count;
        for (int i = 0; i < cnt; ++i)
        {
            if (isPlayerOne)
            {
                shields[i].transform.position = new Vector3(177f + cardSizeX + i * 5f, 155f, 138f);
            }
            else
            {
                shields[i].transform.position = new Vector3(235f - cardSizeX - i * 5f, 155f, 162f);
            }
        }
    }

    public void AddShield(Card card)
    {
        shields.Add(card);
    }

    public Card RemoveShield(int index)
    {
        if (shields.Count - 1 < index)
        {
            return null;
        }
        var card = shields[index];
        shields.RemoveAt(index);
        return card;
    }

    public bool IsEmpty()
    {
        return shields.Count == 0;
    }
}