using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float timeBetweenAttacks = .5f;
    public float damage = 20f;
    
    private float timer;
    private GameObject target;
    private Health health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainBuilding"))
        {
            target = other.gameObject;
            health = target.GetComponent<Health>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainBuilding"))
        {
            target = null;
            health = null;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && target != null)
        {
            _Attack();

            if (health.health == 0)
            {
                Destroy(target);
            }
        }
    }

    private void _Attack()
    {
        timer = 0;
        health.TakeDamage(damage);
        Debug.Log(health.health);
    }
}
