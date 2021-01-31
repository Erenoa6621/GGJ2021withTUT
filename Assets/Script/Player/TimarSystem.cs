using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimarSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float maxTime = 200f;
    [SerializeField] float enemyTouchDownTime;
    [SerializeField] GameObject Player;
    public float nowTime;
    public Text timeText;
    private bool enemyTouch;

    void Start()
    {
        nowTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemyTouch = Player.GetComponent<PlayerSystem>().enemyTouch;

        if (enemyTouch == false)
        {
            nowTime -= Time.deltaTime;
        }
        else
        {
            nowTime -= Time.deltaTime * enemyTouchDownTime;
        }

        if (nowTime < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        timeText.text = nowTime.ToString("F2");
    }

    public float GetNowTime()
    {
        return nowTime;
    }
}
