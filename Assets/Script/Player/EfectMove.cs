using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectMove : MonoBehaviour
{
    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }
}
