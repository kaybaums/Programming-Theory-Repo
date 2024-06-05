using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Animal
{
    private int trees;
    private int rocks;
    private int grass;
    private int food;
    void Awake()
    {
        trees = Random.Range(3, 9);
        grass = Random.Range(1, 4);
        food = 0;
        rocks = Random.Range(1, 7);

        treesWanted = trees;
        rocksWanted = rocks;
        grassWanted = grass;
        foodWanted = food;

        totalWanted = treesWanted + rocksWanted + grassWanted + foodWanted;
        Debug.Log("total " + totalWanted);

        SetVariables();

        animalHappiness = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
}
