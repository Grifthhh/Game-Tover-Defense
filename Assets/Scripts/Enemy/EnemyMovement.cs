using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private GameObject mainBuilding;
    private NavMeshAgent nav;

    private void Start()
    {
        mainBuilding = GameObject.FindGameObjectWithTag("MainBuilding");
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!GameController.isGameOver) {
            nav.SetDestination(mainBuilding.transform.position);
        }
    }
}
