using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [System.Serializable]
    public class CameraArea
    {
        public float up = 90;
        public float down = -110;
        public float left = -100;
        public float right = 100;
        public float _in = 10;
        public float _out = 50;
    }
    public CameraArea cameraArea;
    public float cameraSpeed = 4f;
    public float scrollSpeed = 9f;
    public float shiftSpeedInc = 3f;

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            cameraSpeed /= shiftSpeedInc;
            scrollSpeed /= shiftSpeedInc;
        }

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

        Zoom();

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            cameraSpeed *= shiftSpeedInc;
            scrollSpeed *= shiftSpeedInc;
        }
    }

    private void MoveUp()
    {
        Vector3 pos = transform.position;
        
        if (pos.z < cameraArea.up)
        {
            pos.z += Time.deltaTime * cameraSpeed * 10;
            transform.position = pos;
        }
    }

    private void MoveDown()
    {
        Vector3 pos = transform.position;

        if (pos.z > cameraArea.down)
        {
            pos.z -= Time.deltaTime * cameraSpeed * 10;
            transform.position = pos;
        }
    }

    private void MoveLeft()
    {
        Vector3 pos = transform.position;

        if (pos.x > cameraArea.left)
        {
            pos.x -= Time.deltaTime * cameraSpeed * 10;
            transform.position = pos;
        }
    }

    private void MoveRight()
    {
        Vector3 pos = transform.position;

        if (pos.x < cameraArea.right)
        {
            pos.x += Time.deltaTime * cameraSpeed * 10;
            transform.position = pos;
        }
    }

    private void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if ((transform.position.y > cameraArea._in || scroll < 0) && (transform.position.y < cameraArea._out || scroll > 0))
        {
            transform.Translate(0.0f, 0.0f, Time.deltaTime * scroll * scrollSpeed * 100);
            
        }
        Vector3 pos = transform.position;
        if (transform.position.z > cameraArea.up)
        {
            pos.z = cameraArea.up;
            transform.position = pos;
        }
        if (transform.position.z < cameraArea.down)
        {
            pos.z = cameraArea.down;
            transform.position = pos;
        }
        if (transform.position.x > cameraArea.right)
        {
            pos.x = cameraArea.right;
            transform.position = pos;
        }
        if (transform.position.x < cameraArea.left)
        {
            pos.x = cameraArea.left;
            transform.position = pos;
        }
        if (transform.position.y < cameraArea._in)
        {
            pos.y = cameraArea._in;
            transform.position = pos;
        }
        if (transform.position.y > cameraArea._out)
        {
            pos.y = cameraArea._out;
            transform.position = pos;
        }
    }
}
