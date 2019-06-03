using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playerPowerUp : MonoBehaviour
{

    public GameObject player;
    public bool powerMode = false;
  
    private bool facing;


    public Rigidbody2D fireball;
    public float fireballSpeed = 8f;

 
    public void ActivatePowerUp()
    {
        powerMode = true;
    }

    void Update()
    {
        facing = player.GetComponent<CharacterController2D>().m_FacingRight;
         
        if (Input.GetKey("e"))
        {
            
            if (powerMode==true)
            {
             if (facing == true )
                {
                   
                    var fireballInst = Instantiate(fireball, transform.position, Quaternion.Euler(new Vector2(1f, 0)));
                    fireballInst.velocity = new Vector2(fireballSpeed, 0);
                    powerMode = false;
              
                    

                }
                else
                {
                    var fireballInst = Instantiate(fireball, transform.position, Quaternion.Euler(new Vector3(0, 0,180)));
                    fireballInst.velocity = new Vector2(-fireballSpeed,0);
                    powerMode = false;
                  


                }
                
            }

          
        }
    }

   
}
