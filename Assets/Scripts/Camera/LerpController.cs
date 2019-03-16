using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpController: MonoBehaviour
{
    public float cameraSmoothing = 5f;
    public GameObject cameraOffset;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraOffset.transform.position, cameraSmoothing * Time.deltaTime);
    }
}
