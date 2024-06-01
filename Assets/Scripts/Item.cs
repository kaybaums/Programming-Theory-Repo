using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private BuildingUI buildingUI;
    private Keeper keeper;

    [SerializeField] Material highlightMaterial;
    private Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
        originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
        keeper = GameObject.Find("Keeper").GetComponent<Keeper>();
    }

    private void OnMouseEnter()
    {
        buildingUI.isBlocked = true;
        if (buildingUI.bulldozing)
        {
            gameObject.GetComponent<MeshRenderer>().material = highlightMaterial;
        }
    }

    private void OnMouseExit()
    {
        buildingUI.isBlocked = false;
        gameObject.GetComponent <MeshRenderer>().material = originalMaterial;
    }

    private void OnMouseDown()
    {
        if (buildingUI.bulldozing)
        {
            if (gameObject.CompareTag("Tree"))
            {
                keeper.UpdateTreeCount(gameObject.transform.position);
            }
            else if (gameObject.CompareTag("Rock"))
            {
                keeper.UpdateRocksCount(gameObject.transform.position);
            }
            else if (gameObject.CompareTag("Grass"))
            {
                keeper.UpdateGrassCount(gameObject.transform.position);
            }
            else if (gameObject.CompareTag("Food"))
            {
                keeper.UpdateFoodCount(gameObject.transform.position);
            }
            buildingUI.bulldozing = false;
            buildingUI.isBlocked = false;
            Destroy(gameObject);
        }
    }
}
