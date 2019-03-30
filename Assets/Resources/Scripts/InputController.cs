using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public bool isLeftArrowPressed = false;
    public bool isRightArrowPressed = false;
    public bool isUpArrowPressed = false;
    public bool isDownArrowPressed = false;
    public bool isEnterPressed = false;
    public bool isBackspacePressed = false;
    public bool isShiftPressed = false;

    public void PollForInput()
    {
        ResetKeys();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isLeftArrowPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isRightArrowPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isUpArrowPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isDownArrowPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isEnterPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            isBackspacePressed = true;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            isShiftPressed = true;
        }
    }

    private void ResetKeys()
    {
        isLeftArrowPressed = false;
        isRightArrowPressed = false;
        isUpArrowPressed = false;
        isDownArrowPressed = false;
        isEnterPressed = false;
        isBackspacePressed = false;
        isShiftPressed = false;
    }


}