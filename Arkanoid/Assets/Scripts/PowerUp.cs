using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Power
    {
        BigPaddle,Extrapoints
        // Different power-ups here
    }

    public int PowerUp = 100;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddTorque(Vector3.forward * 2f);
        rigidbody.AddForce(Vector3.right * 3f);
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
        Paddle paddleScript = GameObject.Find("Paddle").GetComponent<Paddle>();
        Paddle.AddPoint(PowerUp);

        AudioSource.PlayClipAtPoint(powerupaudio[0], transform.position);

        Brick brick = GameObject.Find("Brick").GetComponent<Brick>();

        //powerups
        foreach (GameObject pw in brick.powerUpPrefabs)
        {
            switch (pw.transform.name)
            {
                case "Big_Paddle":
                    GameObject.Find("Paddle").transform.localScale += new Vector3(1F, 0, 0);
                    break;
                case "More_Points":
                    paddleScript.AddPoint(1000);
                    break;
            }
        }
    }
}
}
