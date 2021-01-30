using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int battery = 1000;
    [SerializeField] int batteryLostSpeed = 10;
    [SerializeField] int batteryChargeSpeed = 10;
    [SerializeField] GameObject objMark;
    private bool chargeCheck;
    private int charge;
    private int Lost;
    private GameObject objPlayer;
    void Start()
    {
        chargeCheck = false;
        charge = batteryChargeSpeed;
        Lost = batteryLostSpeed;
        objPlayer = GameObject.Find("MainPlayer");

        objMark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (chargeCheck == false)
        {
            if (Lost < 0)
            {
                battery--;
                Lost = batteryLostSpeed;
            }
            if (battery < 0)
            {
                battery = 0;
            }
            Lost--;
        }
        else
        {
            if (charge < 0)
            {
                if (battery < 1000)
                {
                    battery += 2;
                    charge = batteryChargeSpeed;
                }
            }
            charge--;
        }

        // update mark
        if (battery > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            objMark.SetActive(true);
        }
        if (battery <= 0 || Input.GetKeyUp(KeyCode.Space))
        {
            objMark.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chargeCheck = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        chargeCheck = false;
    }

    public int GetBattery()
    {
        return battery;
    }
}
