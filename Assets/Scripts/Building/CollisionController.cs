using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public Material preview;
    public Material previewCantBuild;

    private GameObject buildingManegerObject;
    private BuildingManeger buildingManeger;

    private void Start()
    {
        buildingManegerObject = GameObject.FindGameObjectWithTag("GameController");
        buildingManeger = buildingManegerObject.GetComponent<BuildingManeger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Structure"))
        {
            buildingManeger.isTrigger = true;
            gameObject.GetComponent<MeshRenderer>().material = previewCantBuild;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Structure"))
        {
            buildingManeger.isTrigger = true;
            gameObject.GetComponent<MeshRenderer>().material = previewCantBuild;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Structure"))
        {
            buildingManeger.isTrigger = false;
            gameObject.GetComponent<MeshRenderer>().material = preview;
        }
    }
}
