using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public GameObject player;
   // public GameObject speedEagle;
    public float speed;
    public float jumpSpeed;
    bool isTrigger = false;

    private GameObject player1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (!isTrigger)
        {
            if (other.gameObject.CompareTag("Player"))
            {
               


                print("asdasd");
                player.GetComponent<playerPowerUp>().powerMode = true;
                player.GetComponent<playerPowerUp>().plsWork();
                player.GetComponent<playerPowerUp>().work = 2;
                Destroy(gameObject); // this destroys the bullet

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
