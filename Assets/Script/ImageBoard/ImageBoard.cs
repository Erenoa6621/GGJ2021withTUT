using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageBoard : MonoBehaviour
{
    [SerializeField] GameObject[] imgs;
    [SerializeField] float TimeSpan = 2.0f;
    [SerializeField] float LastTimeSpan = 2.0f;
    int imglength = 0;
    int imgCount = 0;
    float nowtime = 0.0f;
    float nextTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        imglength = imgs.Length;

        foreach (GameObject obj in imgs)
        {
            obj.SetActive(false);
        }
        imgs[0].SetActive(true);
        imgCount++;
    }

    // Update is called once per frame
    void Update()
    {
        bool isNextWait = false;
        bool isNext = false;

        nowtime += Time.deltaTime;
        if(nowtime >= TimeSpan * imgCount)
        {
            if(imgCount >= imglength)
            {
                isNextWait = true;
            }
            else
            {
                foreach (GameObject obj in imgs)
                {
                    obj.SetActive(false);
                }
                imgs[imgCount].SetActive(true);
                imgCount++;
            }
        }

        if(isNextWait == true)
        {
            nextTime += Time.deltaTime;
            if(nextTime > LastTimeSpan)
            {
                isNext = true;
            }
        }

        // next scene
        if (Input.GetKeyUp(KeyCode.Space)
            || Input.GetKeyUp(KeyCode.Return)
            || isNext == true)
        {
            SceneManager.LoadScene("HowToPlay");
        }
    }
}