using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    

    // Update is called once per 
    public void onClick()
    {
        SceneManager.LoadScene("Gameplay");
    } 
}
