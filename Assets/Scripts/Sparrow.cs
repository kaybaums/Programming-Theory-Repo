using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow : Animal
{
    private int trees;
    private int rocks;
    private int grass;
    private int food;

    void Awake()
    {
        DefineWants();

        totalWanted = treesWanted + rocksWanted + grassWanted + foodWanted;
        Debug.Log("total " + totalWanted);

        SetVariables();

        animalHappiness = 0.2f;
    }

    public override void DefineWants()
    {
        trees = Random.Range(1, 6);
        grass = Random.Range(3, 10);
        food = Random.Range(1, 6);
        rocks = Random.Range(1, 3);

        treesWanted = trees;
        rocksWanted = rocks;
        grassWanted = grass;
        foodWanted = food;

        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
}
