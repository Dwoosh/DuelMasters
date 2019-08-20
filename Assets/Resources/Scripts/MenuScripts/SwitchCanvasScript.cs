using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvasScript : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas CardListMenu;
    public CardSettingsHolderScript settingsHolder;


    public void SwitchToMainMenu()
    {
        CardListMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
        MigrateSettingsToHolder();
    }

    public void SwitchToCardListMenu()
    {
        MainMenu.gameObject.SetActive(false);
        CardListMenu.gameObject.SetActive(true);
        var scrollList = CardListMenu.GetComponentInChildren<CardScrollList>();
        scrollList.SetupCardFields();
    }

    private void MigrateSettingsToHolder()
    {
        var scrollList = CardListMenu.GetComponentInChildren<CardScrollList>();
        settingsHolder.fields.AddRange(scrollList.cardFieldList);
        scrollList.cardFieldList.Clear();
    }
}
