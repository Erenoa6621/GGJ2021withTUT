using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int battery = 1000;
    [SerializeField] int batteryLostSpeed = 10;
    [SerializeField] int batteryChargeSpeed = 10;
    [SerializeField] GameObject objMark;
    public AudioClip ChargeSe;
    public AudioClip meetFrend;
    public bool enemyTouch;
    private bool chargeCheck;
    private bool seOn;
    private bool seWait;
    private int charge;
    private int Lost;
    private int seTime = 0;
    private GameObject objPlayer;
    AudioSource audioSource;

    void Start()
    {
        chargeCheck = false;
        charge = batteryChargeSpeed;
        Lost = batteryLostSpeed;
        objPlayer = GameObject.Find("MainPlayer");
        audioSource = GetComponent<AudioSource>();
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
                    seOn = true;
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

        if (seOn == true)
        {
            if (seWait == true)
            {
                audioSource.PlayOneShot(ChargeSe);
                seTime = 60;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "charge")
        {
            chargeCheck = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            enemyTouch = true;
            audioSource.PlayOneShot(meetFrend);
        }
        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("Clear");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "charge")
        {
            chargeCheck = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            enemyTouch = false;
        }

    }

    public int GetBattery()
    {
        return battery;
    }

    public bool IsEnemyTouch()
    {
        return enemyTouch;
    }
}
