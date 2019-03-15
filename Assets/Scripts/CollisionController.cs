using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public Material preview;
    public Material previewCantBuild;

    private GameObject buildingManeger;
    private BuildingController buildingController;

    private void Start()
    {
        buildingManeger = GameObject.FindGameObjectWithTag("BuildingManeger");
        buildingController = buildingManeger.GetComponent<BuildingController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Structure"))
        {
            buildingController.isTrigger = true;
            gameObject.GetComponent<MeshRenderer>().material = previewCantBuild;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Structure"))
        {
            buildingController.isTrigger = true;
            gameObject.GetComponent<MeshRenderer>().material = previewCantBuild;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Structure"))
        {
            buildingController.isTrigger = false;
            gameObject.GetComponent<MeshRenderer>().material = preview;
        }
    }
}
