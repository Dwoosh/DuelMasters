using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvasScript : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas CardListMenu;

    public void SwitchToMainMenu()
    {
        CardListMenu.enabled = false;
        MainMenu.enabled = true;
    }

    public void SwitchToCardListMenu()
    {
        MainMenu.enabled = false;
        CardListMenu.enabled = true;
    }

}
