using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 1;

    private int childCount;
    private List<Vector3> spawnPos = new List<Vector3>();

    private void Awake()
    {
        childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            spawnPos.Add(transform.GetChild(i).position);
        }
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 0, spawnRate);
    }

    private void Spawn()
    {
        int random = Random.Range(0, childCount);
        Instantiate(enemy, spawnPos[random], Quaternion.LookRotation(-spawnPos[random]));
    }
}
