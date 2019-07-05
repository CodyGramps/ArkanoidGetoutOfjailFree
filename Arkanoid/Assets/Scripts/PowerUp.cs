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
    public float speed = 1;

    void OnTriggerEnter(Collider col)
    {
        Paddle paddle = col.GetComponent<Paddle>();
        AudioSource.PlayClipAtPoint(powerupaudio, transform.position);

        if (col.gameObject.name == "Paddle")
        {
            // check what powerup am I
            switch (power)
            {
                case Power.BigPaddle:
                    col.transform.localScale += new Vector3(1F, 0, 0);
                    paddle.speed *= 0.9f;
                    break;
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position += Vector3.down * speed;
    }
=======
    
>>>>>>> Stashed changes
}