using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGamePaused = false;
    public static int libraryCount = 0;
    public Canvas tech;
    public Bullet bullet;
    public Missile missile;
    public Health health;

    public void Start()
    {
        bullet.damage = 5f;
        missile.damage = 5f;
        health.armor = 1f;
    }

    private void Update()
    {
        if (isGameOver)
        {
            Pause();
        }
        else
        {
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

    public void Technology()
    {
        tech.enabled = !tech.enabled;
    }
}
