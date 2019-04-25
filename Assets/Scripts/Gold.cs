using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public static float gold;

    private void Update()
    {
        Text text = GetComponent<Text>();
        text.text = "Gold: " + gold;
    }
}
