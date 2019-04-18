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
        mainBuilding = GameObject.FindGameObjectWithTag("MainBuilding").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nav.SetDestination(mainBuilding.position);
    }
}
