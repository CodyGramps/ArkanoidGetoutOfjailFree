using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Vector3 startVelocity;
    Vector3 velocity;
    Rigidbody rb;
    public bool launched = false;
    public KeyCode launch = KeyCode.Space;
    public float speedIncreaseFactor = 1.05f;
    public float maxSpeed = 10f;
    public Vector3 DebugVel;
    public float DebugSpeed;
    bool bounced = false;
    public int lives;
    float startX;
    float startY;
    public AudioClip paddlesound;

    void Start()
    {
        velocity = startVelocity;
        rb = GetComponent<Rigidbody>();
        startX = transform.position.x;
        startY = transform.position.y;
        lives = 3;
    }

    void respawn()
    {
        transform.position = new Vector3(startX, startY, -1);
        launched = false;
        velocity = startVelocity;
        lives -= 1;
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
        DebugVel = velocity;
        DebugSpeed = velocity.magnitude;
        while (Mathf.Abs(velocity.x) <= 1f || Mathf.Abs(velocity.y) <= 3f)
        {
            velocity = Quaternion.Euler(0, 0, Random.Range(-45, 45)) * velocity;
        }
        if (lives == 0)
        {
            SceneManager.LoadScene("HighScores");
        }
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
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        while (Mathf.Abs(velocity.x) <= 1f || Mathf.Abs(velocity.y) <= 3f)
        {
            velocity = Quaternion.Euler(0, 0, Random.Range(-45, 45)) * velocity;
        }

        if (collision.gameObject.name == "Paddle" && paddlesound)
        {
            AudioSource.PlayClipAtPoint(paddlesound, transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "botomBorder")
        {
            respawn();
        }
    }
}
