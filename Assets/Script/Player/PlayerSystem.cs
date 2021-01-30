using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int battery = 1000;
    [SerializeField] int batteryLostSpeed = 10;
    [SerializeField] int batteryChargeSpeed = 10;
    public bool chargeCheck;
    public int charge;
    public int Lost;
    void Start()
    {
        chargeCheck = false;
        charge = batteryChargeSpeed;
        Lost = batteryLostSpeed;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "charge")
        {
            chargeCheck = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "charge")
        {
            chargeCheck = false;
        }
    }

    public int GetBattery()
    {
        return battery;
    }
}
