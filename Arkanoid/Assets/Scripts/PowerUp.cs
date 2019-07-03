using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Power
    {
        Nothing,
        BigPaddle
    }
    public Power power;
    public AudioClip powerupaudio;

    public AudioClip powerupaudio;
    void OnCollisionEnter(Collision col)
    {
        Paddle paddle = GameObject.Find("Paddle").GetComponent<Paddle>();
        AudioSource.PlayClipAtPoint(powerupaudio, transform.position);

        if (col.gameObject.name == "Paddle")
        {
            // check what powerup am I
            switch (gameObject.name)
            {
                case "Big_Paddle":
                    GameObject.Find("Paddle").transform.localScale += new Vector3(1F, 0, 0);
                    break;
            }
            Destroy(gameObject);
        }
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