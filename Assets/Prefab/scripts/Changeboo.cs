﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeboo : MonoBehaviour
{

    public GameObject player;
    public GameObject vase;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
            player.GetComponent<playerPowerUp>().plsWork();
        }

        if (Input.GetKeyDown("i"))
        {
            var VaseInst = Instantiate(vase, transform.position, Quaternion.Euler(new Vector2(5, 0)));
        }
    }
}
