using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CardField : MonoBehaviour
{
    public InputField cardInputField;
    public Text cardAmountText;
    public Text cardNameText;
    public Image cardImage;
    public Button incrementButton;
    public Button decrementButton;

    private CardInfo cardInfo;
    private CardScrollList cardScrollList;

    void Start()
    {
        incrementButton.onClick.AddListener(HandleIncrementButtonClick);
        decrementButton.onClick.AddListener(HandleDecrementButtonClick);
    }

    public void Setup(CardInfo card, CardScrollList scrollList)
    {
        cardScrollList = scrollList;
        cardInfo = card;
        cardNameText.text = card.name;
        cardImage.sprite = GetSpriteFromResources(card.name);
    }

    private void HandleIncrementButtonClick()
    {
        var textValue = int.Parse(cardAmountText.text);
        if (textValue < 4)
        {
            cardAmountText.text = (textValue + 1).ToString();
        }
    }

    private void HandleDecrementButtonClick()
    {
        var textValue = int.Parse(cardAmountText.text);
        if (textValue > 0)
        {
            cardAmountText.text = (textValue - 1).ToString();
        }
    }

    private static Sprite GetSpriteFromResources(string cardName)
    {
        var path = "Sprites/Cards/" + GetSpecializedName(cardName);
        return Resources.Load<Sprite>(path);
    }

    private static string GetSpecializedName(string cardName)
    {
        var rgx = new Regex("[^a-zA-Z]");
        cardName = string.Join("", cardName.Split(',')[0]);
        return rgx.Replace(cardName, "");
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
    public List<CardInfo> list;
}