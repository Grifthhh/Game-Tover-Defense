using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform mainBuilding;
    private NavMeshAgent nav;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        GameObject mb = GameObject.FindGameObjectWithTag("MainBuilding");
        
        if (mb != null)
        {
            mainBuilding = mb.transform;
        }
        else
        {
            mainBuilding = null;
        }
        
        if (mainBuilding != null)
        {
            nav.SetDestination(mainBuilding.position);
        }
        else
        {
            Debug.Log("oyun bitti");
        }
    }
}
