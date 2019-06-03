using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{

    private GameObject player;

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
                player.GetComponent<playerPowerUp>().ActivatePowerUp();
                Destroy(gameObject); // this destroys the powerup
            }
      
    }

 
}
