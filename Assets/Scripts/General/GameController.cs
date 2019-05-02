using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isGamePaused;
    public static int libraryCount;
    public Canvas tech;
    public Bullet bullet;
    public Missile missile;
    public Health health;
    public float scienceTimer;

    private float timer;

    public void Start()
    {
        isGameOver = false;
        isGamePaused = false;
        libraryCount = 0;
        /*
        bullet.damage = 5f;
        missile.damage = 5f;
        health.armor = 1f;
        */
    }

    private void Update()
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

        EarnScience();
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

    public void EarnScience()
    {
        timer += Time.deltaTime;

        if (timer > scienceTimer && libraryCount != 0)
        {
            timer = 0;
            Science.science += libraryCount;
        }
    }
}
