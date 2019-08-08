using UnityEngine;
using UnityEngine.UI;

public class CardFieldScript : MonoBehaviour
{
    public InputField cardInputField;
    public Text cardAmountText;
    public Text cardNameText;
    public Image cardImage;
    public Button incrementButton;
    public Button decrementButton;
    
    private CardScrollList cardScrollList;

    void Start()
    {
        incrementButton.onClick.AddListener(HandleIncrementButtonClick);
        decrementButton.onClick.AddListener(HandleDecrementButtonClick);
    }

    public void Setup(Card card, CardScrollList scrollList)
    {
        cardScrollList = scrollList;
        cardNameText.text = card.cardName;
        cardImage.sprite = GetSpriteFromResources(card.cardName);
    }

    public void HandleIncrementButtonClick()
    {
        var textValue = int.Parse(cardAmountText.text);
        if (textValue < 4)
        {
            cardAmountText.text = (textValue + 1).ToString();
        }
    }

    public void HandleDecrementButtonClick()
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
        return string.Join("", cardName.Split(',')[0]);
    }
}
