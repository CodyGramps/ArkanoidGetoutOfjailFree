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

}