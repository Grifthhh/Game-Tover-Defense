using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button goldBtn;
    public Button libBtn;
    public Button bulBtn;
    public Button misBtn;

    public static bool isGameOver;
    public static bool isGamePaused;
    public static int libraryCount;
    public static int goldCount;
    public static int permissionGold;
    public static int permissionLibrary;
    public float scienceTimer;
    public float goldTimer;
    public static float goldRate;
    public static float scienceRate;

    [Header("Technology")]
    public Canvas military;
    public Canvas economic;
    public Canvas scienceC;

    [Header("Bullet")]
    public Bullet bullet;
    public float bDamage;

    [Header("Missile")]
    public Missile missile;
    public float mDamage;

    [Header("Health")]
    public Health health;
    public float armor;

    private float sTimer;
    private float gTimer;

    public void Start()
    {
        isGameOver = false;
        isGamePaused = false;
        libraryCount = 0;
        goldCount = 0;
        
        bullet.damage = bDamage;
        missile.damage = mDamage;
        health.armor = armor;

        goldRate = 1f;
        scienceRate = 1f;

        goldBtn.interactable = false;
        bulBtn.interactable = false;
        misBtn.interactable = false;

        permissionGold = 0;
        permissionLibrary = 1;
    }

    private void Update()
    {
        if (libraryCount == 1)
        {
            bulBtn.interactable = true;
            misBtn.interactable = true;
        }

        if (permissionGold > goldCount)
        {
            goldBtn.interactable = true;
        }
        else
        {
            goldBtn.interactable = false;
        }

        if (permissionLibrary > libraryCount)
        {
            libBtn.interactable = true;
        }
        else
        {
            libBtn.interactable = false;
        }

        sTimer += Time.deltaTime;
        gTimer += Time.deltaTime;

        GainScience();
        GainGold();

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

    public void Military()
    {
        military.enabled = !military.enabled;
    }

    public void Economic()
    {
        economic.enabled = !economic.enabled;
    }

    public void ScienceC()
    {
        scienceC.enabled = !scienceC.enabled;
    }

    public void GainScience()
    {
        if (sTimer > scienceTimer && libraryCount != 0)
        {
            sTimer = 0;
            Science.science += libraryCount * scienceRate;
        }
    }

    public void GainGold()
    {
        if (gTimer > goldTimer && goldCount != 0)
        {
            gTimer = 0;
            Gold.gold += goldCount * goldRate;
        }
    }
}
