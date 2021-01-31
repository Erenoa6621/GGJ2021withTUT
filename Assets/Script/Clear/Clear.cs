using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)
            || Input.GetKeyUp(KeyCode.Return))
        {
            int stageNo = PlayerPrefs.GetInt("STAGE");
            if(stageNo == 0)
            {
                PlayerPrefs.SetInt("STAGE", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Stage1_full3");
            }
            else
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }
}
