using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextController
{
    public Text controlsTextObject;
    public Text infoTextObject;

    public UITextController()
    {
        controlsTextObject = GameObject.Find("UI/ControlsText").GetComponent<Text>();
        infoTextObject = GameObject.Find("UI/InfoText").GetComponent<Text>();
    }

    public void UpdateControlsText(string controlsText)
    {
        controlsTextObject.text = controlsText;
    }

    public void UpdateInfoText(string infoText)
    {
        infoTextObject.text = infoText;
    }
}
