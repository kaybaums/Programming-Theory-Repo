using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deer : Animal
{

    void Start()
    {
        treesWanted = Random.Range(1, 7);
        grassWanted = Random.Range(1, 12);
        foodWanted = Random.Range(1, 10);
        rocksWanted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Walk();
    }

}
