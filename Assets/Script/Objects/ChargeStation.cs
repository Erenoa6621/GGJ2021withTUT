using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeStation : MonoBehaviour
{
    [SerializeField] GameObject objMark;
    GameObject objPlayer;

    // Start is called before the first frame update
    void Start()
    {
        objMark.SetActive(false);
        objPlayer = GameObject.Find("MainPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        int battery = objPlayer.GetComponent<PlayerSystem>().GetBattery();

        if(battery > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            objMark.SetActive(true);
        }
        if(battery <= 0 || Input.GetKeyUp(KeyCode.Space))
        {
            objMark.SetActive(false);
        }
    }
}
