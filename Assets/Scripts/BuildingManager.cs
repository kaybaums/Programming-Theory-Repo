using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingManager : MonoBehaviour
{
    // Buildable Game Prefabs are public to communicate with UI script
    public GameObject firTree;
    public GameObject sakuraTree;
    public List<GameObject> rocksList;
    public List<GameObject> grassList;
    public List<GameObject> foodList;
    public GameObject[] animals;

    private BuildingUI buildingUI;
    private Keeper keeper;
    private AdoptAnimal adoptAnimal;


    // Start is called before the first frame update
    void Start()
    {
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
        keeper = GameObject.Find("Keeper").GetComponent <Keeper>();
        adoptAnimal = GameObject.Find("Animal UI").GetComponent<AdoptAnimal>();

    }

    public void SpawnItemToBuild(int index, Vector3 position)
    {
        // check which item to spawn and update animal nave mesh surface
        
        if (index == 0)
        {
            Instantiate(firTree, position, Quaternion.identity);
            keeper.UpdateTreeCount(position);
            keeper.CalcHabitatQuality();
            keeper.CheckHabitatQuality();
        }
        else if (index == 1)
        {
            Instantiate(sakuraTree, position, Quaternion.identity);
            keeper.UpdateTreeCount(position);
            keeper.CalcHabitatQuality();
            keeper.CheckHabitatQuality();
        }
        else if (index == 2)
        {
            Instantiate(rocksList[buildingUI.rockIndex], position, Quaternion.identity);
            keeper.UpdateRocksCount(position);
            keeper.CalcHabitatQuality();
            keeper.CheckHabitatQuality();
        }
        else if (index == 3)
        {
            Instantiate(grassList[buildingUI.grassIndex], position, Quaternion.identity);
            keeper.UpdateGrassCount(position);
            keeper.CalcHabitatQuality();
            keeper.CheckHabitatQuality();
        }
        else if (index == 4)
        {
            Instantiate(foodList[buildingUI.foodIndex], position, Quaternion.identity);
            keeper.UpdateFoodCount(position);
            keeper.CalcHabitatQuality();
            keeper.CheckHabitatQuality();
        }

        gameObject.GetComponent<UpdateNavMeshSurface>().UpdateWalkableEnvironment();
    }

    public void SpawnAdoptedAnimal(int index, Vector3 position)
    {
        if (index == 0)
        {
            GameObject adoptedAnimal = Instantiate(animals[index], position, Quaternion.identity);
            Animal ani_script = adoptedAnimal.GetComponent<Animal>();
            keeper.animals.Add(adoptedAnimal);
            keeper.UpdateHabitatNeeds(ani_script.treesWanted, ani_script.rocksWanted, ani_script.grassWanted, ani_script.foodWanted);
            keeper.CalcHabitatQuality();
        }
        else if (index == 1)
        {
            GameObject adoptedAnimal = Instantiate(animals[index], position, Quaternion.identity);
            Animal ani_script = adoptedAnimal.GetComponent<Animal>();
            keeper.animals.Add(adoptedAnimal);
            keeper.UpdateHabitatNeeds(ani_script.treesWanted, ani_script.rocksWanted, ani_script.grassWanted, ani_script.foodWanted);
            keeper.CalcHabitatQuality();
        }
        else if (index == 2)
        {
            GameObject adoptedAnimal = Instantiate(animals[index], position, Quaternion.identity);
            Animal ani_script = adoptedAnimal.GetComponent<Animal>();
            keeper.animals.Add(adoptedAnimal);
            keeper.UpdateHabitatNeeds(ani_script.treesWanted, ani_script.rocksWanted, ani_script.grassWanted, ani_script.foodWanted);
            keeper.CalcHabitatQuality();
        }

    }

}
