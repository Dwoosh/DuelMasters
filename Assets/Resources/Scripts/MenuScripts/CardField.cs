using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CardField : MonoBehaviour, IComparable<CardField>
{
    public InputField cardInputField;
    public Text cardAmountText;
    public Text cardNameText;
    public Image cardImage;
    public Button incrementButton;
    public Button decrementButton;
    public Text allCardCountText;

    private CardInfo cardInfo;
    private CardScrollList cardScrollList;

    private int cardCount = 0;
    private static int allCardsCount = 0;

    public void Setup(CardInfo card, CardScrollList scrollList)
    {
        allCardCountText = FindObjectsOfType<Text>().First(x => x.name == "CardCountText");
        cardScrollList = scrollList;
        cardInfo = card;
        cardNameText.text = card.name;
        cardImage.sprite = GetSpriteFromResources(card.name);
    }

    public void HandleIncrementButtonClick()
    {
        if (cardCount < 4 && allCardsCount < 40)
        {
            ++cardCount;
            ++allCardsCount;
            SetCardCountTexts();
        }
    }

    public void HandleDecrementButtonClick()
    {
        if (cardCount > 0 && allCardsCount > 0)
        {
            --cardCount;
            --allCardsCount;
            SetCardCountTexts();
        }
    }

    public void HandleOnValueChangedEvent()
    {
        
    }
    
    private void SetCardCountTexts()
    {
        allCardCountText.text = allCardsCount.ToString() + " / 40";
        cardInputField.text = cardCount.ToString();
    }
    
    private static Sprite GetSpriteFromResources(string cardName)
    {
        var path = "Sprites/CardSprites/" + GetSpecializedName(cardName) + "Sprite";
        return Resources.Load<Sprite>(path);
    }

    private static string GetSpecializedName(string cardName)
    {
        var rgx = new Regex("[^a-zA-Z]");
        cardName = string.Join("", cardName.Split(',')[0]);
        return rgx.Replace(cardName, "");
    }

    public int CompareTo(CardField other)
    {
        if (other == null) return 1;
        return string.Compare(cardNameText.text, other.cardNameText.text, StringComparison.Ordinal);
    }
}

[System.Serializable]
public class CardInfo
{
    public string name;
}

[System.Serializable]
public class CardInfoList
{
    public List<CardInfo> list = new List<CardInfo>();
}