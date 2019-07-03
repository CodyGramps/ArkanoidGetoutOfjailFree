using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public PowerUp.Power power = PowerUp.Power.BigPaddle;
    public int hitsToKill;
    public int points;
    private int numberOfHits;
    public GameObject powerUpPrefab;

    // Use this for initialization
    void Start()
    {
        numberOfHits = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (power != PowerUp.Power.Nothing)
            {
                if (powerUpPrefab)
                {
                    GameObject powerup = Instantiate(powerUpPrefab);
                    powerup.GetComponent<PowerUp>().power = power;
                }
            }
            Destroy(gameObject);
        }
    }
}