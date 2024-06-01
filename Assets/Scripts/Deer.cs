using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : Animal
{
    private int treesNeeded;
    private int grassNeeded;
    private int mushroomNeeded;

    void Awake()
    {
        treesNeeded = Random.Range(1, 7);
        grassNeeded = Random.Range(1, 12);
        mushroomNeeded = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }


}
