using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    private float speed = 5.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up *  speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

        
        transform.Rotate(Vector3.up, Time.deltaTime * speed);

        if (transform.position.y > 5.0f)
        {
            Destroy(gameObject);
        }

    }
}
