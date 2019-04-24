using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManeger : MonoBehaviour
{
    public GameObject structure;
    public GameObject structurePreview;
    public int rotationSpeed = 1;
    public CanvasRenderer imageRenderer;

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
            }
        }
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
        if (!isTrigger && ClickableFlag.clickable)
        {
            Instantiate(structure, tmpPreview.transform.position, tmpPreview.transform.GetChild(0).gameObject.transform.rotation);

            if (flag){
                Destroy(tmpPreview);
            }
        }
    }

    private void BuildingGetKey()
    {
        if (tmpPreview != null)
        {
            PreviewMoving();
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.GetKey(KeyCode.LeftShift))
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
