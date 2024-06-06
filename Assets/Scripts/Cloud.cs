using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float topBound;
    [SerializeField] private float bottomBound;
    private float speed;
    private bool goingUp = true;
    private void Awake()
    {
        speed = Random.Range(0.2f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            FloatUp();
            if (transform.position.y > topBound)
            {
                goingUp = false;
            }
        } else
        {
            FloatDown();
            if (transform.position.y < bottomBound)
            {
                goingUp = true;
            }
        }

    }

    private void FloatUp()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void FloatDown()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
