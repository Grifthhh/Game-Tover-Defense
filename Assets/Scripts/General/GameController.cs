using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isGamePaused;
    public static int libraryCount;
    public float scienceTimer;
    public Canvas tech;

    [Header("Bullet")]
    public Bullet bullet;
    public float bDamage;

    [Header("Missile")]
    public Missile missile;
    public float mDamage;

    [Header("Health")]
    public Health health;
    public float armor;

    private float timer;

    public void Start()
    {
        isGameOver = false;
        isGamePaused = false;
        libraryCount = 0;
        
        bullet.damage = bDamage;
        missile.damage = mDamage;
        health.armor = armor;
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
