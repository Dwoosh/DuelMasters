using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameScript : MonoBehaviour
{

    public bool gamePaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                Time.timeScale = 0f;
                gamePaused = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
                gamePaused = false;
                Time.timeScale = 1.0f;
            }
        }
    }
}