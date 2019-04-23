using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject mainPrt;
    public float timeBetweenAttacks = .5f;
    public float damage = 20f;
    public EnemySpawner enemySpawner;
    
    private float timer;
    private GameObject target = null;
    private Health health;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            GameObject prt = Instantiate(mainPrt, target.transform);
            Destroy(prt, 2f);
        }
    }

    private void _Attack()
    {
        timer = 0;
        health.TakeDamage(damage);
        audioSource.Play();
    }
}
