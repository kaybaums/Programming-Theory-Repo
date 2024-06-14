using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : Animal
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

        animalHappiness = 0.15f;
    }
    public override void DefineWants()
    {
        trees = Random.Range(1, 7);
        grass = Random.Range(1, 7);
        food = Random.Range(1, 7);
        rocks = 0;

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
