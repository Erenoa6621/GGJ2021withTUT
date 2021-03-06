﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject objMobile;
    [SerializeField] GameObject objGameover;
    [SerializeField] GameObject objEffect;
    [SerializeField] GameObject objStressLevel;
    [SerializeField] GameObject objPhoneOpen;
    [SerializeField] GameObject objTrap;
    [SerializeField] TextMeshProUGUI tmproText;
    [SerializeField] Image objImage;
    [SerializeField] int lowPower;
    [SerializeField] int middlePower;
    [SerializeField] int midHightPower;
    [SerializeField] GameObject objPlayer;
    [SerializeField] GameObject objTimer;
    [SerializeField] TextMeshProUGUI tmproTimer;
    [SerializeField] GameObject objSkip;
    [SerializeField] float dispSkipSpan;

    int stageNo;
    float dispSkipTimer;

    // Start is called before the first frame update
    void Start()
    {
        objMobile.SetActive(true);
        objGameover.SetActive(false);
        objEffect.SetActive(true);

        objPhoneOpen.GetComponent<Animator>().SetBool("iSHoldingSpace", false);

        objTrap.SetActive(true);
        objTrap.GetComponent<Animator>().SetBool("MetFriend", false);
        objTrap.SetActive(false);

        stageNo = PlayerPrefs.GetInt("STAGE");
        dispSkipTimer = 0.0f;
        objSkip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       // objGameover.SetActive(false);
        // バッテリー更新
        int battery = objPlayer.GetComponent<PlayerSystem>().GetBattery();
        SetGauge(battery);

        // タイマー更新
        float nowTimer = objTimer.GetComponent<TimarSystem>().GetNowTime();
        tmproTimer.text = nowTimer.ToString();

        // トラップ踏んだ？
        bool isTrap = objTimer.GetComponent<TimarSystem>().IsEnemyTouch();
        if(Input.GetKey(KeyCode.Return))
        {
            isTrap = true;
        }
        //if(Input.GetKey(KeyCode.A))
        //{
        //    isTrap = false;
        //}
        if(isTrap == true)
        {
            objTrap.SetActive(true);
            objTrap.GetComponent<Animator>().SetBool("MetFriend", true);
        }
        else
        {
            objTrap.GetComponent<Animator>().SetBool("MetFriend", false);
            objTrap.SetActive(false);
        }

        // スマホオープン、クローズ
        if (Input.GetKeyDown(KeyCode.Space) && battery > 0)
        {
            objMobile.SetActive(true);
            objPhoneOpen.GetComponent<Animator>().SetBool("iSHoldingSpace", true);
        }
        if(Input.GetKeyUp(KeyCode.Space) || battery <= 0)
        {
            objMobile.SetActive(true);
            objPhoneOpen.GetComponent<Animator>().SetBool("iSHoldingSpace", false);
        }

        // Tutorial Skip
        if(stageNo == 0)
        {
            dispSkipTimer += Time.deltaTime;
            if(dispSkipTimer < dispSkipSpan)
            {
                objSkip.SetActive(true);
            }
            else if(dispSkipTimer < dispSkipSpan * 2.0f)
            {
                objSkip.SetActive(false);
            }
            else if(dispSkipTimer >= dispSkipSpan * 2.0f)
            {
                dispSkipTimer -= dispSkipSpan * 2.0f;
            }

            if(Input.GetKeyDown(KeyCode.P))
            {
                PlayerPrefs.SetInt("STAGE", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Stage1_full3");
            }
        }
    }

    void SetGauge(int power)
    {
        int dispPower = (int)(power / 10);
        float dispBarLength = (float)power / 1000.0f;

        tmproText.text = dispPower.ToString() + "%";

        objImage.fillAmount = dispBarLength;

        if (power <= lowPower)
        {
            objImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            objStressLevel.GetComponent<Animator>().SetInteger("StressLevel", 3);
        }
        else if(power < middlePower)
        {
            objImage.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            objStressLevel.GetComponent<Animator>().SetInteger("StressLevel", 2);
        }
        else if(power < midHightPower)
        {
            objStressLevel.GetComponent<Animator>().SetInteger("StressLevel", 1);
        }
        else
        {
            objImage.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            objStressLevel.GetComponent<Animator>().SetInteger("StressLevel", 0);
        }
    }
}
