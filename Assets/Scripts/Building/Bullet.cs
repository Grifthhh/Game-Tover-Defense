using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //private GameObject target;
    public float damage; //init in GameController
    private Transform target;
    private EnemyHealth health;
    public GameObject bulletCrash;
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

        if (direction.magnitude <= (distanceThisFrame + 1f))
        {
            HitTarget();
            GameObject prt = Instantiate(blood, target.transform.position, target.transform.rotation);
            Destroy(prt, 2);
            health.TakeDamage(damage);
            Debug.Log(damage);

            if (health.health <= 0)
            {
                Destroy(target, .1f);
            }

            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject efekt = (GameObject)Instantiate(bulletCrash, transform.position, transform.rotation);
        Destroy(efekt, 2f);
        Destroy(gameObject);
    }
}
