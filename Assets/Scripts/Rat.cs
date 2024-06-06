using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Animal
{
    private int trees;
    private int rocks;
    private int grass;
    private int food;

    private void Awake()
    {
        trees = Random.Range(3, 6);
        grass = Random.Range(2, 8);
        food = Random.Range(1, 6);
        rocks = Random.Range(1, 3);

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