using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarEnemy : MonoBehaviour
{
    public Slider slider;
    public Image healthBar;

    private EnemyHealth health;

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (slider.value < 40)
        {
            healthBar.color = Color.red;
        }
        else
        {
            healthBar.color = Color.white;
        }

        slider.value = health.health;
    }
}
