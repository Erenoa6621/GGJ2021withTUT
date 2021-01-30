using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimarSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float maxTime = 200f;
    public float nowTime;
    public Text timeText;

    void Start()
    {
        nowTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        nowTime -= Time.deltaTime;
        timeText.text = nowTime.ToString("F2");
    }
}
