using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public GameObject goblin;
    public GameObject dev;

    public float spawnTime = .1f;
    public float waveTime = 10f;

    private int pos;
    private int count;
    private int spawnCount;
    private float timer;
    private float waveTimer;
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
        count = 0;
        spawnCount = 0;
        timer = 0;
        waveTimer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        waveTimer += Time.deltaTime;

        if (waveTimer > waveTime)
        {
            count++;
            spawnCount = count;
            pos = Pos();
            waveTimer = 0;
        }
        
        if (timer > spawnTime && spawnCount != 0)
        {
            if (spawnCount == 3)
            {
                SpawnDev(pos);
            }
            else
            {
                SpawnGoblin(pos);
            }

            spawnCount--;
        }
    }

    private int Pos()
    {
        int pos = Random.Range(0, childCount);
        return pos;
    }

    private void SpawnGoblin(int random)
    {
        timer = 0;
        
        Instantiate(goblin, spawnPos[random], Quaternion.LookRotation(-spawnPos[random]));
    }

    private void SpawnDev(int random)
    {
        timer = 0;
        
        Instantiate(dev, spawnPos[random], Quaternion.LookRotation(-spawnPos[random]));
    }
}
