using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject blood;
    public float damage = 40f;
    public float area = 5f;
    private Transform target;

    private EnemyHealth health;
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
            /*
            health.TakeDamage(damage);
            Explode();
            if (health.health <= 0)
            {
                Destroy(target, .1f);
            }
            */
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    //Diğer hedeflere vurmayı optimize et
    void Explode()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, area);
        foreach(Collider collider in colliders)
        {
            //Her Enemy'de 2 collider olduğu için collider sayısını düzeltiyoruz.
            SphereCollider doubleColliderFix = collider as SphereCollider;
            if(doubleColliderFix != null)
            {
                if (collider.tag == "Enemy")
                {
                    health = collider.GetComponent<EnemyHealth>();
                    GameObject prt = Instantiate(blood, collider.transform.position, collider.transform.rotation);
                    Destroy(prt, 2);
                    health.TakeDamage(damage);

                }
            }

        }
    }

    void HitTarget()
    {
        
        Explode();
        Destroy(gameObject);
    }
}
