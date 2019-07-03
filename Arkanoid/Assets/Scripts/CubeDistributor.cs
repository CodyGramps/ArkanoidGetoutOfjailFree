using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDistributor : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            Brick b = transform.GetChild(i).gameObject.AddComponent<Brick>();
            if (Random.Range(0, 100) >= 90)
            {
                b.power = PowerUp.Power.BigPaddle;
            }
        }
    }
}
