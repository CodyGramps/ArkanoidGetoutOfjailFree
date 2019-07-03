using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public PowerUp.Power power = PowerUp.Power.NOTHING;
    public int hitsToKill;
    public int points;
    private int numberOfHits;

    // Use this for initialization
    void Start()
    {
        numberOfHits = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}