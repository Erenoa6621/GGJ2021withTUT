using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadAut : MonoBehaviour
{
    public bool loadLost = false;
    public int check = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Load")
        {
            loadLost = false;
        }       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Load")
        {
            Exit();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Load")
        {
            check++;
        }
    }

    void Exit()
    {
        check -= 1;
        if (check < 1)
        {
            loadLost = true;
        }

    }

}
