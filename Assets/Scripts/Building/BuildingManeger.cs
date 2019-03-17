using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManeger : MonoBehaviour
{
    public GameObject structure;
    public GameObject structurePreview;
    public int rotationSpeed = 1;

    private int floorLayer;
    private GameObject tmpPreview;
    private Vector3 offset;
    private Vector3 hitPoint;
    public bool isTrigger { get; set; }

    private void Start()
    {
        floorLayer = LayerMask.GetMask("Floor");
    }

    public void Update()
    {
        BuildingGetKey();
    }

    private void Preview()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 200f, floorLayer))
        {
            if (tmpPreview == null)
            {
                hitPoint = hit.point;
                tmpPreview = Instantiate(structurePreview, hit.point, Quaternion.identity);
            }        }
    }

    private void PreviewMoving()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 200f, floorLayer))
        {
            offset = hit.point - hitPoint;
            hitPoint = hit.point;
            tmpPreview.transform.Translate(offset);
        }
    }

    private void PreviewRotation(bool direction)
    {
        if (direction)
        {
            tmpPreview.transform.GetChild(0).gameObject.transform.Rotate(Vector3.up, 100 * rotationSpeed * Time.deltaTime);
        }
        else
        {
            tmpPreview.transform.GetChild(0).gameObject.transform.Rotate(-Vector3.up, 100 * rotationSpeed * Time.deltaTime);
        }
    }

    private void BuildStructure(bool flag)
    {
        if (!isTrigger)
        {
            Instantiate(structure, tmpPreview.transform.position, tmpPreview.transform.GetChild(0).gameObject.transform.rotation);

            if (flag){
                Destroy(tmpPreview);
            }
        }
        else
        {
            Debug.Log("Kurulamaz!");
        }
    }

    private void BuildingGetKey()
    {
        if (tmpPreview != null)
        {
            PreviewMoving();
            if (Input.GetMouseButtonDown(1))
            {
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    BuildStructure(false);
                }
                else
                {
                    BuildStructure(true);
                }
            }
            if (Input.GetKey(KeyCode.E))
            {
                PreviewRotation(true);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                PreviewRotation(false);
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Destroy(tmpPreview);
            }
        }
    }

    public void chooseStructure()
    {
        Preview();
    }
}
