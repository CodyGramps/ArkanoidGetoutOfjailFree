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
    float hitTimer;
    public AnimationCurve hitanim;
    Vector3 start;

    // Use this for initialization
    void Start()
    {
        numberOfHits = 0;
        start = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;
            transform.localPosition = start + Vector3.up * hitanim.Evaluate(hitanim.keys[hitanim.keys.Length - 1].time - hitTimer);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;
            hitTimer = hitanim.keys[hitanim.keys.Length - 1].time;
            ScoreDisplay.score += 10;
            if (numberOfHits >= hitsToKill)
            {
                if (power != PowerUp.Power.Nothing)
                {
                    if (powerUpPrefab)
                    {
                        GameObject powerup = Instantiate(powerUpPrefab);
                        powerup.GetComponent<PowerUp>().power = power;
                        powerup.transform.position = transform.position;
                    }
                }
                ScoreDisplay.score += 100;
                Destroy(gameObject);
            }
        }
    }
}