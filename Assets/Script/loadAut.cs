using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadAut : MonoBehaviour
{
    public bool loadLost = false;
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
        if (collision.gameObject.tag == "floor")
        {
            loadLost = true;
        }
        if (collision.gameObject.tag == "Load")
        {
            loadLost = false;
        }
       

    }

}
