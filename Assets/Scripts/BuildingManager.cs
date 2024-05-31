using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    // Buildable Game Prefabs are public to communicate with UI script
    [SerializeField] public GameObject firTree;
    [SerializeField] public GameObject sakuraTree;
    [SerializeField] public List<GameObject> rocksList;
    [SerializeField] public List<GameObject> grassList;
    [SerializeField] public List<GameObject> mushroomList;

    private BuildingUI buildingUI;
    public UpdateTextCounter updateTextCounter;

    // Start is called before the first frame update
    void Start()
    {
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
        updateTextCounter = GameObject.FindWithTag("Counter").GetComponent <UpdateTextCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItemToBuild(int index, Vector3 position)
    {
        // check which item to spawn and update animal nave mesh surface
        
        if (index == 0)
        {
            Instantiate(firTree, position, Quaternion.identity);
            updateTextCounter.UpdateTreeCount();
        }
        else if (index == 1)
        {
            Instantiate(sakuraTree, position, Quaternion.identity);
            updateTextCounter.UpdateTreeCount();
        }
        else if (index == 2)
        {
            Instantiate(rocksList[buildingUI.rockIndex], position, Quaternion.identity);
            updateTextCounter.UpdateRocksCount();
        }
        else if (index == 3)
        {
            Instantiate(grassList[buildingUI.grassIndex], position, Quaternion.identity);
            updateTextCounter.UpdateGrassCount();
        }
        else if (index == 4)
        {
            Instantiate(mushroomList[buildingUI.mushIndex], position, Quaternion.identity);
            updateTextCounter.UpdateMushroomCount();
        }
        
    }

}
