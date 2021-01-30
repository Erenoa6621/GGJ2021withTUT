using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject objMobilePrefab;
    GameObject objMobile;

    // Start is called before the first frame update
    void Start()
    {
        objMobile = Instantiate(objMobilePrefab, Vector3.zero, Quaternion.identity);
        objMobile.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            objMobile.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Return))
        {
            objMobile.SetActive(false);
        }
    }
}
