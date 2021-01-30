using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintIn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FootPrint;
    float time = 0;

    void Update()
    {
        this.time += Time.deltaTime;
        if (this.time > 0.35f)
        {
            this.time = 0;
            Instantiate(FootPrint, transform.position, transform.rotation);
        }
    }
}
