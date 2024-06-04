using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deer : Animal
{
    public int trees;
    public int rocks;
    public int grass;
    public int food;


    void Awake()
    {
        trees = Random.Range(1, 7);
        grass = Random.Range(1, 7);
        food = Random.Range(1, 7);
        rocks = 0;

        Debug.Log(trees);

        treesWanted = trees;
        rocksWanted = rocks;
        grassWanted = grass;
        foodWanted = food;

        totalWanted = treesWanted + rocksWanted + grassWanted + foodWanted;
        Debug.Log("total " + totalWanted);

        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

}
