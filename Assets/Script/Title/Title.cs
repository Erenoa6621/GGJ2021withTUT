﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            SceneManager.LoadScene("Credits");
        }
        else if (Input.GetKeyUp(KeyCode.Space)
            || Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Introduction");
        }
    }
}
