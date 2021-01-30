using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int battery = 1000;
    public bool chargeCheck;
    void Start()
    {
        chargeCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (chargeCheck == false)
        {
            battery--;
            if (battery < 0)
            {
                battery = 0;
            }
        }
        else
        {
            if (battery < 1000)
            {
                battery += 2;
            }
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
}
