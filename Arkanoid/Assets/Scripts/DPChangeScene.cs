using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 2f;
    public string newScene = "";

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            SceneManager.LoadScene(newScene);
        }
    }
}
