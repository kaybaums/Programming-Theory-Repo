using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keeper : MonoBehaviour
{
    // the purpose of this script is to keep track of the quality of the habitat and report game end scenarios

    public Slider qualitySlider;

    private float habitatQuality = 0.4f;

    public GameObject[] animals;
    public int treesCurrent { get; private set; }
    public int rocksCurrent { get; private set; }
    public int grassesCurrent { get; private set; }
    public int foodCurrent { get; private set; }
    public int totalCurrent { get; private set; }

    // these variables represent the number of items needed for the habitat to be considered good quality
    private static int treesNeeded 
    { 
        get { return treesNeeded; }
        set
        {
            if (value < 0)
            {
                // trees needed cannot be negative
                value = 0;
            }
            else
            {
                treesNeeded = value;
            }
        }
    }
    private static int rocksNeeded 
    {
        get { return rocksNeeded; }
        set
        {
            if (value < 0)
            {
                // rocks needed cannot be negative
                value = 0;
            }
            else
            {
                rocksNeeded = value;
            }
        }
    }
    private static int grassesNeeded 
    {
        get { return grassesNeeded; }
        set
        {
            if (value < 0)
            {
                // grasses needed cannot be negative
                value = 0;
            }
            else
            {
                grassesNeeded = value;
            }
        }
    }
    private static int foodNeeded
    {
        get { return foodNeeded; }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            else
            {
                foodNeeded = value;
            }
        }
    }

    private BuildingUI buildingUI;

    private bool gameWon = false;
    private bool gameLost = false;

    // Start is called before the first frame update
    void Start()
    {
        qualitySlider = GameObject.Find("Habitat Quality").GetComponent<Slider>();
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animals !=  null)
        {
            CalcHabitatQuality();
            CheckHabitatQuality();
        }

        qualitySlider.value = habitatQuality;

    }

    void CalcHabitatQuality()
    {
        float totalHappiness = 0.0f;
        
        for (int i = 0; i < animals.Length; i++)
        {
            totalHappiness += animals[i].GetComponent<Animal>().animalHappiness;
        }

        habitatQuality = totalHappiness / animals.Length;
    }

    void CheckHabitatQuality()
    {
        // player wins the game if the habitat quality is above 80%
        if (habitatQuality > 0.8f)
        {
            gameWon = true;
            GameWon();

        } else if (habitatQuality < 0.15f) // player loses the game if the habitat quality falls below 15%
        {
            gameLost = true;
            GameLost();
        }
    }

    void GameWon()
    {

    }

    void GameLost()
    {

    }

    private void UpdateCurrentTotal()
    {
        totalCurrent = treesCurrent + rocksCurrent + grassesCurrent + foodCurrent;
    }

    public void UpdateHabitatNeeds(int trees, int rocks, int grass, int food)
    {
        // this method is called every time an animal is adopted or sold
        treesNeeded += trees;
        rocksNeeded += rocks;
        grassesNeeded += grass;
        foodNeeded += food;
    }

    public void UpdateTreeCount()
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            treesCurrent--;
            UpdateCurrentTotal();
            for (int i = 0; i < animals.Length; i++)
            {
                //animal check happiness
            }
        }
        else
        {
            treesCurrent++;
            UpdateCurrentTotal();
            for (int i = 0; i < animals.Length; i++)
            {
                //animal check happiness
                // update animal destination
            }
        }
        
    }

    public void UpdateRocksCount()
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            rocksCurrent--;
            UpdateCurrentTotal();
            for (int i = 0; i < animals.Length; i++)
            {
                //animal check happiness
            }
        }
        else
        {
            rocksCurrent++;
            UpdateCurrentTotal();
            for (int i = 0; i < animals.Length; i++)
            {
                //animal check happiness
                // update animal destination
            }
        }
        
    }

    public void UpdateGrassCount()
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            grassesCurrent--;
            UpdateCurrentTotal();
            for (int i = 0; i < animals.Length; i++)
            {
                //animal check happiness
            }
        }
        else
        {
            grassesCurrent++;
            UpdateCurrentTotal();
            for (int i = 0; i < animals.Length; i++)
            {
                //animal check happiness
                // update animal destination
            }
        }

    }

    public void UpdateFoodCount()
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            foodCurrent--;
            UpdateCurrentTotal();
            for (int i = 0; i < animals.Length; i++)
            {
                //animal check happiness
            }
        }
        else
        {
            foodCurrent++;
            UpdateCurrentTotal();
            for (int i = 0; i < animals.Length; i++)
            {
                //animal check happiness
                // update animal destination
            }
        }
        
    }
}
