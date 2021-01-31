using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("STAGE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
