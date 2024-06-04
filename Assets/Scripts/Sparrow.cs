using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow : Animal
{
    void Start()
    {
        treesWanted = Random.Range(1, 6);
        grassWanted = Random.Range(3, 10);
        foodWanted = Random.Range(1, 6);
        rocksWanted = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
}
