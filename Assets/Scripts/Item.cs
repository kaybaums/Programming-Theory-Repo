using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private BuildingUI buildingUI;
    private UpdateTextCounter updateTextCounter;

    [SerializeField] Material highlightMaterial;
    private Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
        originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
        updateTextCounter = GameObject.FindWithTag("Counter").GetComponent<UpdateTextCounter>();
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
                updateTextCounter.UpdateTreeCount();
            }
            else if (gameObject.CompareTag("Rock"))
            {
                updateTextCounter.UpdateRocksCount();
            }
            else if (gameObject.CompareTag("Grass"))
            {
                updateTextCounter.UpdateGrassCount();
            }
            else if (gameObject.CompareTag("Mushroom"))
            {
                updateTextCounter.UpdateMushroomCount();
            }
            buildingUI.bulldozing = false;
            buildingUI.isBlocked = false;
            Destroy(gameObject);
        }
    }
}
