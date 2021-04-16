using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
