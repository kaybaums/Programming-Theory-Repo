using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Animal
{
    private int trees;
    private int rocks;
    private int grass;
    private int food;

    private void Awake()
    {
        trees = Random.Range(0, 2);
        grass = Random.Range(1, 5);
        food = Random.Range(1, 3);
        rocks = Random.Range(3, 8);

        treesWanted = trees;
        rocksWanted = rocks;
        grassWanted = grass;
        foodWanted = food;

        totalWanted = treesWanted + rocksWanted + grassWanted + foodWanted;
        Debug.Log("total " + totalWanted);

        SetVariables();

        animalHappiness = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
}
