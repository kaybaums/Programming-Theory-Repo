using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateTextCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI treesText;
    [SerializeField] TextMeshProUGUI rocksText;
    [SerializeField] TextMeshProUGUI grassesText;
    [SerializeField] TextMeshProUGUI mushroomsText;

    private int treesMax;
    private int rocksMax;
    private int grassesMax;
    private int mushroomsMax;

    [SerializeField] int treesCurrent = 0;
    [SerializeField] int rocksCurrent = 0;
    [SerializeField] int grassesCurrent = 0;
    [SerializeField] int mushroomsCurrent = 0;

    public bool treesMet = false;
    public bool rocksMet = false;
    public bool grassesMet = false;
    public bool mushroomsMet = false;

    private Animal animal;
    private BuildingUI buildingUI;

    // Start is called before the first frame update
    void Start()
    {
        // Get random number of items needed per type and update text

        treesMax = Random.Range(1, 7);
        treesText.text = treesCurrent + " / " + treesMax + " Trees";

        rocksMax = Random.Range(1, 11);
        rocksText.text = rocksCurrent + " / " + rocksMax + " Rocks";

        grassesMax = Random.Range(1, 21);
        grassesText.text = grassesCurrent + " / " + grassesMax + " Grasses";

        mushroomsMax = Random.Range(1, 21);
        mushroomsText.text = mushroomsCurrent + " / " + mushroomsMax + " Mushrooms";

        animal = GameObject.Find("Animal").GetComponent<Animal>();
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
    }

    public void UpdateTreeCount()
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            treesCurrent--;
            treesText.text = treesCurrent + " / " + treesMax + " Trees";
            if (treesCurrent >= treesMax)
            {
                animal.LookHappy();
            }
            else if (treesCurrent < treesMax)
            {
                animal.LookSad();
            }
        } else
        {
            treesCurrent++;
            treesText.text = treesCurrent + " / " + treesMax + " Trees";
            if (treesCurrent <= treesMax)
            {
                animal.LookHappy();
            }
            else if (treesCurrent > treesMax)
            {
                animal.LookSad();
            }
        }
        if (treesCurrent == treesMax)
        {
            treesMet = true;
        }
        else
        {
            treesMet = false;
        }
    }

    public void UpdateRocksCount()
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            rocksCurrent--;
            rocksText.text = rocksCurrent + " / " + rocksMax + " Rocks";
            if (rocksCurrent >= rocksMax)
            {
                animal.LookHappy();
            }
            else if (rocksCurrent < rocksMax)
            {
                animal.LookSad();
            }
        }
        else
        {
            rocksCurrent++;
            rocksText.text = rocksCurrent + " / " + rocksMax + " Rocks";
            if (rocksCurrent <= rocksMax)
            {
                animal.LookHappy();
            }
            else if (rocksCurrent > rocksMax)
            {
                animal.LookSad();
            }
        }
        if (rocksCurrent == rocksMax)
        {
            rocksMet = true;
        }
        else
        {
            rocksMet = false;
        }
    }

    public void UpdateGrassCount()
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            grassesCurrent--;
            grassesText.text = grassesCurrent + " / " + grassesMax + " Grasses";
            if (grassesCurrent >= grassesMax)
            {
                animal.LookHappy();
            }
            else if (grassesCurrent < grassesMax)
            {
                animal.LookSad();
            }
        }
        else
        {
            grassesCurrent++;
            grassesText.text = grassesCurrent + " / " + grassesMax + " Grasses";
            if (grassesCurrent <= grassesMax)
            {
                animal.LookHappy();
            }
            else if (grassesCurrent > grassesMax)
            {
                animal.LookSad();
            }
        }
        if (grassesCurrent == grassesMax)
        {
            grassesMet = true;
        }
        else
        {
            grassesMet = false;
        }
    }

    public void UpdateMushroomCount()
    {
        if (buildingUI.bulldozing && Input.GetMouseButtonDown(0))
        {
            mushroomsCurrent--;
            mushroomsText.text = mushroomsCurrent + " / " + mushroomsMax + " Mushrooms";
            if (mushroomsCurrent >= mushroomsMax)
            {
                animal.LookHappy();
            }
            else if (mushroomsCurrent < mushroomsMax)
            {
                animal.LookSad();
            }
        }
        else
        {
            mushroomsCurrent++;
            mushroomsText.text = mushroomsCurrent + " / " + mushroomsMax + " Mushrooms";
            if (mushroomsCurrent <= mushroomsMax)
            {
                animal.LookHappy();
            }
            else if (mushroomsCurrent > mushroomsMax)
            {
                animal.LookSad();
            }
        }
        if (mushroomsCurrent == mushroomsMax)
        {
            mushroomsMet = true;
        }
        else
        {
            mushroomsMet = false;
        }
    }
}
