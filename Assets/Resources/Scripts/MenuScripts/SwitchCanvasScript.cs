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
        MigrateSettingsToHolder();
        CardListMenu.enabled = false;
        MainMenu.enabled = true;
    }

    public void SwitchToCardListMenu()
    {
        var scrollList = CardListMenu.GetComponentInChildren<CardScrollList>();
        scrollList.SetupCardFields();
        MainMenu.enabled = false;
        CardListMenu.enabled = true;
    }

    private void MigrateSettingsToHolder()
    {
        var scrollList = CardListMenu.GetComponentInChildren<CardScrollList>();
        settingsHolder.fields.AddRange(scrollList.cardFieldList);
        scrollList.cardFieldList.Clear();
    }
}
