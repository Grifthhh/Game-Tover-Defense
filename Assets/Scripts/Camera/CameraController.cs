using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [System.Serializable]
    public class CameraArea
    {
        public float up = 85.57f;
        public float down = -114.43f;
        public float left = -100;
        public float right = 100;
        public float _in = 10;
        public float _out = 50;
    }
    public CameraArea cameraArea;
    public float cameraSpeed = 4f;
    public float scrollSpeed = 9f;
    public float shiftSpeedInc = 3f;
    public new Camera camera;
    public Toggle keyboard;
    public Toggle mouse;

    private LayerMask floorLayer;
    private Vector3 offset;
    private Vector3 hitPoint;
    private Vector3 tmpHitPoint;
    private Vector3 firstCameraPosition;

    private void Start()
    {
        floorLayer = LayerMask.GetMask("Floor");
        firstCameraPosition = transform.position;
    }

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Zoom();

        if (keyboard.isOn)
        {
            MoveWithKeyboar();
        }
        
        if (mouse.isOn)
        {
            MoveWithMouse();
        }
    }

    private void MoveWithKeyboar()
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
    }
    private void MoveWithMouse()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 200f, floorLayer))
            {
                tmpHitPoint = hit.point - (transform.position - firstCameraPosition);
            }
        }

        if (Input.GetMouseButton(1))
        {
            MoveWithMause();
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

    private void MoveWithMause()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 200f, floorLayer))
        {
            hitPoint = hit.point - (transform.position - firstCameraPosition);
            offset = hitPoint - tmpHitPoint;
            tmpHitPoint = hitPoint;
        }
        transform.Translate(-offset, Space.World);
        camera.transform.Translate(-offset * 8 / 10, Space.World);
    }
}
