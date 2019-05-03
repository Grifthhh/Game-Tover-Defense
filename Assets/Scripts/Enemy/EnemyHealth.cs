using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public float armor = 1f;
    public int gold;

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
