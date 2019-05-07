using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider;
    public Image healthBar;

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
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
