using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniCon : MonoBehaviour
{
    public Animator PlayerAni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerAni.SetTrigger("TrueRight");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerAni.SetTrigger("TrueLeft");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerAni.SetTrigger("Up");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerAni.SetTrigger("Down_Left");
        }


    }
}
