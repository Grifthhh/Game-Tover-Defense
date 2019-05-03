using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public GameObject blood;
    public float range = 20f;
    public float damage = 20f;
    public float fireRate = 1f;

    private EnemyHealth health;
    private GameObject target;
    private AudioSource audioS;

    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void Start()
    {
        InvokeRepeating("Shoot", 1, fireRate);
    }

    private void Update()
    {
        UpdateTarget();
    }

    private void Shoot()
    {
        if (target != null)
        {
            health = target.GetComponent<EnemyHealth>();

            GameObject prt = Instantiate(blood, target.transform.position, target.transform.rotation);
            Destroy(prt, 2);

            health.TakeDamage(damage);
            audioS.Play();

            if (health.health <= 0)
            {
                Destroy(target, .1f);
            }
        }
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (shortDistance > distance)
            {
                shortDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortDistance <= range)
        {
            target = nearestEnemy;
        }
    }
}
