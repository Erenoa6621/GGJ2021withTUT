﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject objMobile;
    [SerializeField] GameObject objEffect;
    [SerializeField] TextMeshProUGUI tmproText;
    [SerializeField] Image objImage;
    [SerializeField] int lowPower;
    [SerializeField] int middlePower;
    [SerializeField] GameObject objPlayer;

    // Start is called before the first frame update
    void Start()
    {
        objMobile.SetActive(false);
        objEffect.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // バッテリー更新
        int battery = objPlayer.GetComponent<PlayerSystem>().GetBattery();
        SetGauge(battery);

        if(Input.GetKeyDown(KeyCode.Space) && battery > 0)
        {
            objMobile.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Space) || battery <= 0)
        {
            objMobile.SetActive(false);
        }
    }

    void SetGauge(int power)
    {
        int dispPower = (int)(power / 10);
        float dispBarLength = (float)power / 1000.0f;

        tmproText.text = dispPower.ToString() + "%";

        objImage.fillAmount = dispBarLength;

        if(power <= lowPower)
        {
            objImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        else if(power < middlePower)
        {
            objImage.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        }
        else
        {
            objImage.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        }
    }
}
