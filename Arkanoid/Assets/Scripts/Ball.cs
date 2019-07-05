﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 startVelocity;
    Vector3 velocity;
    Rigidbody rb;
    public bool launched = false;
    public KeyCode launch = KeyCode.Space;
    public float speedIncreaseFactor = 1.05f;
    bool bounced = false;
    float startX;
    float startY;

    void Start()
    {
        velocity = startVelocity;
        rb = GetComponent<Rigidbody>();
        float startX = transform.position.x;
        float startY = transform.position.y;
    }

    void respawn()
    {
        velocity = startVelocity;
        transform.position = new Vector3(startX, startY, -1);
    }

    void Update()
    {
        if (launched)
        {
            rb.velocity = velocity;
        }
        else
        {
            rb.velocity = Vector3.zero;
            if (Input.GetKey(launch))
                launched = true;
        }
        bounced = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (bounced)
            return;
        bounced = true;
        float dx = Mathf.Abs(collision.contacts[0].point.x - transform.position.x);
        float dy = Mathf.Abs(collision.contacts[0].point.y - transform.position.y);
        float epsilon = 0.1f;
        if (dx + epsilon >= dy)
        {
            velocity.x *= -1;
        }
        if (dy + epsilon >= dx)
        {
            velocity.y *= -1;
        }
        velocity *= speedIncreaseFactor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "botomBorder")
        {
            respawn();
            launched = false;
        }
            
    }
}
