using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Animal
{
    void Start()
    {
        treesWanted = Random.Range(3, 9);
        grassWanted = Random.Range(1, 4);
        foodWanted = 0;
        rocksWanted = Random.Range(1, 7);
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
}
