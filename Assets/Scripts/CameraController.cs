using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [System.Serializable]
    public class CameraArea
    {
        public float up;
        public float down;
        public float left;
        public float right;
    }
    public CameraArea cameraArea;
    public float cameraSpeed = 1;

    private void Start()
    {
        
    }

    private void Update()
    {
        moveCamera();
    }

    public void moveCamera()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos.z += Time.deltaTime * 10;
            transform.position = pos;
        }
    }
}
