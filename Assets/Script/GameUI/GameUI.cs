using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject objMobilePrefab;
    GameObject objMobile;
    TextMeshProUGUI tmproText;

    // Start is called before the first frame update
    void Start()
    {
        objMobile = Instantiate(objMobilePrefab, Vector3.zero, Quaternion.identity);

        //GameObject obj = GameObject.Find("UI_Battery_FILL_Function");
        //obj.GetComponent<TextMeshPro>().text = "100%";
        //tmproText.name = "100%";

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
