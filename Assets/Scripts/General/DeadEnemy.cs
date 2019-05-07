using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadEnemy : MonoBehaviour
{
    public static float deadEnemy;

    private void Start()
    {
        deadEnemy = 0;
    }

    private void Update()
    {
        Text text = GetComponent<Text>();
        text.text = "Dead Enemy: " + deadEnemy;
    }
}
