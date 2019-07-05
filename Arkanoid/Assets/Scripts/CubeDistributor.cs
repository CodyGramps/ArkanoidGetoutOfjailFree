using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDistributor : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i).gameObject.GetComponent<Brick>())
                continue;
            Brick b = transform.GetChild(i).gameObject.AddComponent<Brick>();
            b.power = PowerUp.Power.Nothing;
            if (Random.Range(0, 100) >= 90)
            {
                b.power = PowerUp.Power.BigPaddle;
                Debug.Log("Put power up at " + b.transform.position);
            }
        }
    }
}
