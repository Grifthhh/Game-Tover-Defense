using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Science : MonoBehaviour
{
    public static float science;

    private void Start()
    {
        science = 0;
    }

    private void Update()
    {
        Text text = GetComponent<Text>();
        text.text = "Science: " + science;
    }
}
