using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float maxSize = 10;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newVel = new Vector2(0, 0);
        if (Input.GetKey("a"))
        {
            newVel.x = -speed;
        }
        if (Input.GetKey("d"))
        {
            newVel.x = speed;
        }
        
        GetComponent<Rigidbody>().velocity = new Vector3(newVel.x, transform.position.y, 0);
        if (transform.localScale.x > maxSize)
        {
            transform.localScale = new Vector3(maxSize, transform.localScale.y, transform.localScale.z);
        }
    }
}
