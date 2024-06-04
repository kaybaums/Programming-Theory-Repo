using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keeper : MonoBehaviour
{
    // the purpose of this script is to keep track of the quality of the habitat and report game end scenarios

    public Slider qualitySlider;
    private GameManager gameManager;

    private float habitatQuality = 0.4f;

    public List<GameObject> animals;
    public int treesCurrent { get; private set; }
    public int rocksCurrent { get; private set; }
    public int grassesCurrent { get; private set; }
    public int foodCurrent { get; private set; }

    // these variables represent the number of items needed for the habitat to be considered good quality
    private int treesNeeded = 0;
    private int rocksNeeded = 0;
    private int grassesNeeded = 0;
    private int foodNeeded = 0;

    private BuildingUI buildingUI;

    public bool gameWon = false;
    public bool gameLost = false;

    // Start is called before the first frame update
    void Start()
    {
        qualitySlider = GameObject.Find("Habitat Quality").GetComponent<Slider>();
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
        gameManager = GameObject.Find("Focal Point").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        qualitySlider.value = habitatQuality;

    }

    public void CalcHabitatQuality()
    {
        // instead of happiness calculate needs vs current
        /* float totalHappiness = 0.0f;
        
        for (int i = 0; i < animals.Length; i++)
        {
            Animal ani_script = animals[i].GetComponent<Animal>();
            
            totalHappiness += ani_script.animalHappiness;
        }

        habitatQuality = totalHappiness / animals.Length; */

        float treeRatio = (float)treesCurrent / (float)treesNeeded;
        float rockRatio = (float)rocksCurrent / (float)rocksNeeded;
        float grassRatio = (float)grassesCurrent / (float)grassesNeeded;
        float foodRatio = (float)foodCurrent / (float)foodNeeded;

        habitatQuality = (treeRatio + rockRatio + grassRatio + foodRatio) / 4.0f;

    }

    public void CheckHabitatQuality()
    {
        // player wins the game if the habitat quality is above 80%
        if (habitatQuality >= 0.8f)
        {
            gameWon = true;
            gameManager.GameOver();

        } else  // player loses the game if the habitat quality falls below 15%
        {
            for (int i = 0; i < animals.Count; i++)
            {
                // check if animal happiness falls below %15
                if (animals[i].GetComponent<Animal>().animalHappiness < 0.15)
                {
                    // check if habitat quality is also below %15
                    if (habitatQuality < 0.15f)
                    {
                        gameLost = true;
                        gameManager.GameOver();
                        break; // stop loop when game is lost
                    }
                }
            }
        }
    }

    public void UpdateHabitatNeeds(int trees, int rocks, int grass, int food)
    {
        // this method is called every time an animal is adopted or sold
        treesNeeded += trees;
        rocksNeeded += rocks;
        grassesNeeded += grass;
        foodNeeded += food;

        Debug.Log("trees: " +  treesNeeded);
        Debug.Log("rocks: " + rocksNeeded);
        Debug.Log("grass: " + grassesNeeded);
        Debug.Log("food: " + foodNeeded);
    }

    public void UpdateTreeCount(Vector3 position)
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            treesCurrent--;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness();
            }
        }
        else
        {
            treesCurrent++;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness();
                Debug.Log("Checking animal happiness");
                // update animal destination
                ani_script.SetNewDestination(position);
            }
        }
        
    }

    public void UpdateRocksCount(Vector3 position)
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            rocksCurrent--;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness();
            }
        }
        else
        {
            rocksCurrent++;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness();

                // update animal destination
                ani_script.SetNewDestination(position);
            }
        }
        
    }

    public void UpdateGrassCount(Vector3 position)
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            grassesCurrent--;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness();
            }
        }
        else
        {
            grassesCurrent++;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness();

                // update animal destination
                ani_script.SetNewDestination(position);
            }
        }

    }

    public void UpdateFoodCount(Vector3 position)
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            foodCurrent--;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness();
            }
        }
        else
        {
            foodCurrent++;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness();

                // update animal destination
                ani_script.SetNewDestination(position);
            }
        }
        
    }
}
