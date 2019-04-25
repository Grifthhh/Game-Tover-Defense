using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //private GameObject target;
    public float damage = 40f;
    private Transform target;
    private EnemyHealth health;

    public GameObject blood;
    public float speed = 40f;

    public void Seek(Transform target2)
    {
        target = target2;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        health = target.GetComponent<EnemyHealth>();

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= (distanceThisFrame + 2f))
        {
            HitTarget();
            GameObject prt = Instantiate(blood, target.transform.position, target.transform.rotation);
            Destroy(prt, 2);
            health.TakeDamage(damage);
            Debug.Log(damage);

            if (health.health <= 0)
            {
                Destroy(target, .1f);
                Gold.gold += 10;
            }

            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}
