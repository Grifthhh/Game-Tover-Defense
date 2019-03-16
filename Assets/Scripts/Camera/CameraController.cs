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
    public float cameraSpeed = 5f;
    public float scrollSpeed = 1f;

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        ZoomIn();
        ZoomOut();
    }

    private void MoveUp()
    {
        Vector3 pos = transform.position;
        pos.z += Time.deltaTime * cameraSpeed * 10;
        transform.position = pos;
    }

    private void MoveDown()
    {
        Vector3 pos = transform.position;
        pos.z -= Time.deltaTime * cameraSpeed * 10;
        transform.position = pos;
    }

    private void MoveLeft()
    {
        Vector3 pos = transform.position;
        pos.x -= Time.deltaTime * cameraSpeed * 10;
        transform.position = pos;
    }

    private void MoveRight()
    {
        Vector3 pos = transform.position;
        pos.x += Time.deltaTime * cameraSpeed * 10;
        transform.position = pos;
    }

    private void ZoomIn()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0.0f, 0.0f,  Time.deltaTime * scroll * scrollSpeed);
    }

    private void ZoomOut()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0.0f, 0.0f, Time.deltaTime * scroll * scrollSpeed * 1000);
    }
}
