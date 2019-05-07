using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    public Text text1;
    public Text text2;

    private void Update()
    {
        text1.text = "Time to Next Wave : " + (int) (enemySpawner.waveTime - enemySpawner.waveTimer);
        text2.text = "Wave Count : " + enemySpawner.count;
    }
}
