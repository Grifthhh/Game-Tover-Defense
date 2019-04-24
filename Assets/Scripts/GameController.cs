using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGamePaused = false;
    

    private void Update()
    {
        if (isGameOver)
        {
            Pause();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isGamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (isGamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    private void Pause()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
    }
}
