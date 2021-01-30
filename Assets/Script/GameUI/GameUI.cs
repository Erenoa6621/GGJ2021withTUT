using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject objMobile;
    [SerializeField] GameObject objGameover;
    [SerializeField] GameObject objEffect;
    [SerializeField] GameObject objStressLevel;
    [SerializeField] GameObject objPhoneOpen;
    [SerializeField] TextMeshProUGUI tmproText;
    [SerializeField] Image objImage;
    [SerializeField] int lowPower;
    [SerializeField] int middlePower;
    [SerializeField] int midHightPower;
    [SerializeField] GameObject objPlayer;

    // Start is called before the first frame update
    void Start()
    {
        objMobile.SetActive(true);
        objGameover.SetActive(false);
        objEffect.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        objGameover.SetActive(false);
        // バッテリー更新
        int battery = objPlayer.GetComponent<PlayerSystem>().GetBattery();
        SetGauge(battery);

        if(Input.GetKeyDown(KeyCode.Space) && battery > 0)
        {
            objMobile.SetActive(true);
            objPhoneOpen.GetComponent<Animator>().SetBool("iSHoldingSpace", true);
        }
        if(Input.GetKeyUp(KeyCode.Space) || battery <= 0)
        {
            objMobile.SetActive(true);
            objPhoneOpen.GetComponent<Animator>().SetBool("iSHoldingSpace", false);
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
