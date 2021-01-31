using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniCon : MonoBehaviour
{
    public Animator PlayerAni;
    public AudioClip walkSe;
    AudioSource audioSource;
    private int seTime = 60;
    private bool seOn;
    private bool seWait;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerAni.SetTrigger("TrueRight");
            PlayerAni.SetFloat("Speed",10f);
            seOn = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerAni.SetTrigger("TrueLeft");
            PlayerAni.SetFloat("Speed", 10f);
            seOn = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerAni.SetTrigger("Up");
            PlayerAni.SetFloat("Speed", 10f);
            seOn = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            PlayerAni.SetTrigger("Down_Left");
            PlayerAni.SetFloat("Speed", 10f);
            seOn = true;
        }

        if (seOn == true)
        {
            if (seWait == true)
            {
                audioSource.PlayOneShot(walkSe);
                seTime = 120;
                seWait = false;
            }
            else if (seTime < 0)
            {
                seWait = true;
            }
            seTime--;
            seOn = false;
        }
    }

   


}
