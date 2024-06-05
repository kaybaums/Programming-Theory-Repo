using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keeper : MonoBehaviour
{
    // the purpose of this script is to keep track of the quality of the habitat and report game end scenarios

    public Slider qualitySlider;
    private GameManager gameManager;

    private float habitatQuality = 0.0f;

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

        float treeRatio;
        float rockRatio;
        float grassRatio;
        float foodRatio;

        float average = 0;

        if (treesNeeded != 0)
        {
            average++;
            // check if there are too many items
            if (treesCurrent > treesNeeded)
            {
                float treePenalty = (((float)treesCurrent / (float)treesNeeded) - (float)treesCurrent % (float)treesNeeded);

                treeRatio = ((float)treesCurrent / (float)treesNeeded) - treePenalty;
            }
            else
            {
                treeRatio = (float)treesCurrent / (float)treesNeeded;
            }
        } else
        {
            treeRatio = 0;
        }
        if (rocksNeeded != 0)
        {
            average++;
            if (rocksCurrent > rocksNeeded)
            {
                float rockPenalty = (((float)rocksCurrent / (float)rocksNeeded) - (float)rocksCurrent % (float)rocksNeeded);

                rockRatio = ((float)rocksCurrent / (float)rocksNeeded) - rockPenalty;
            }
            else
            {
                rockRatio = (float)rocksCurrent / (float)rocksNeeded;
            }
        } else
        {
            rockRatio = 0;
        }
        if (grassesNeeded != 0)
        {
            average++;
            if (grassesCurrent > grassesNeeded)
            {
                float grassPenalty = (((float)grassesCurrent / (float)grassesNeeded) - (float)grassesCurrent % (float)grassesNeeded);

                grassRatio = ((float)grassesCurrent / (float)grassesNeeded) - grassPenalty;
            }
            else
            {
                grassRatio = (float)grassesCurrent / (float)grassesNeeded;
            }

        } else
        {
            grassRatio = 0;
        }
        if (foodNeeded != 0)
        {
            average++;
            if (foodCurrent > foodNeeded)
            {
                float foodPenalty = (((float)foodCurrent / (float)foodNeeded) - (float)foodCurrent % (float)foodNeeded);

                foodRatio = ((float)foodCurrent/ (float)foodNeeded) - foodPenalty;
            }
            else
            {
                foodRatio = (float)foodCurrent / (float)foodNeeded;
            }
        }
        else
        {
            foodRatio = 0;
        }

        habitatQuality = (treeRatio + rockRatio + grassRatio + foodRatio) / average;
       
    }

    public void CheckHabitatQuality()
    {
        // player wins the game if the habitat quality is above 80%
        if (habitatQuality == 1.0f)
        {
            gameWon = true;
            gameManager.GameOver();

        } else if (habitatQuality < 0.1f) 
        {
            // player loses the game if habitat quality is poor and animals are unhappy
            CheckAnimals();
        }
    }

    public void CheckAnimals()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            // check if animal happiness falls below %15
            if (animals[i].GetComponent<Animal>().animalHappiness < 0.15)
            {
                gameLost = true;
                gameManager.GameOver();
                break; // stop loop when game is lost
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
    }

    public void UpdateTreeCount(Vector3 position)
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            treesCurrent--;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness("tree");
            }
        }
        else
        {
            treesCurrent++;

            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness("tree");
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
                ani_script.CheckAnimalHappiness("rock");
            }
        }
        else
        {
            rocksCurrent++;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness("rock");

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
                ani_script.CheckAnimalHappiness("grass");
            }
        }
        else
        {
            grassesCurrent++;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness("grass");

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
                ani_script.CheckAnimalHappiness("food");
            }
        }
        else
        {
            foodCurrent++;
            
            for (int i = 0; i < animals.Count; i++)
            {
                //animal check happiness
                Animal ani_script = animals[i].GetComponent<Animal>();
                ani_script.CheckAnimalHappiness("food");

                // update animal destination
                ani_script.SetNewDestination(position);
            }
        }
        
    }
}
