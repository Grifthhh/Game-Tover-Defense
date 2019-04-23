using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform rotationControl;
    public GameObject blood;
    public float range = 20f;
    public float damage = 20f;
    public float fireRate = 1f;

    private GameObject target;
    private Health health;

    void Start()
    {
        InvokeRepeating("Shoot", 1, fireRate);
    }

    
    void Update()
    {
        UpdateTarget();
        
    }

    private void Shoot()
    {
        if (target != null)
        {
            health = target.GetComponent<Health>();

            GameObject prt = Instantiate(blood, target.transform.position, target.transform.rotation);
            Destroy(prt, 2);
            
            health.TakeDamage(damage);

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

        Vector3 direction;

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

            direction = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 dir = lookRotation.eulerAngles;
            rotationControl.rotation = Quaternion.Euler(0f, dir.y, 0f);

        }
    }
}
