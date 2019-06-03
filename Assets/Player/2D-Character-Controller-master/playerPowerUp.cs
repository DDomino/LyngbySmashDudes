﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playerPowerUp : MonoBehaviour
{

    public GameObject player;
    public bool powerMode = false;
    public int work = 1;
    
   
    private bool facing;


    public Rigidbody2D fireball;
    public float fireballSpeed = 8f;

 



    public AudioClip impact;
    AudioSource audioSource;


    void awake()

    {
    }

        






    public void plsWork()
    {
        powerMode = true;
    }

    void Update()
    {
        facing = player.GetComponent<CharacterController2D>().m_FacingRight;
         
        if (Input.GetKey("e"))
        {
            
            if (work == 2 || powerMode==true)
            {

                

                if (facing == true )
                {
                    audioSource.PlayOneShot(impact, 0.7f);
                    var fireballInst = Instantiate(fireball, transform.position, Quaternion.Euler(new Vector2(1f, 0)));
                    fireballInst.velocity = new Vector2(fireballSpeed, 0);
                    

                    Debug.Log("Fire Fire Fire");
                    powerMode = false;
                    work = 1;
                    

                }
                else
                {

                    var fireballInst = Instantiate(fireball, transform.position, Quaternion.Euler(new Vector3(0, 0,180)));
                    fireballInst.velocity = new Vector2(-fireballSpeed,0);
                    
                    Debug.Log("Fire Fire Fire");
                    powerMode = false;
                    work = 1;
                   


                }
                
            }

          
        }
    }

   
}
