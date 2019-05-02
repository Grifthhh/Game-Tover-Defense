using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float armor;
    public int gold;

    private void Start()
    {
        health = 100f;
        armor = 1f;
    }

    public void TakeDamage(float damage)
    {
        health -= damage / armor;

        if (health < 0)
        {
            health = 0;
        }
    }

    private void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            Gold.gold += gold;
        }
    }
}
