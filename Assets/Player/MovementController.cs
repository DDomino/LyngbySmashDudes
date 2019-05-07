using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public CharacterController2D controller;

    float horizontalMove = 0f;
    bool jump = false;
    public float runSpeed = 40f;

   


    public Animator animator;
  

    // Update is called once per frame

  


    public void SpeedBoost(float amount)
    {
        runSpeed += amount;
    }

void Update()
    {
     animator.SetFloat("MovementSpeed", Mathf.Abs(horizontalMove));

        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
         //   animator.SetBool("isJumping", true);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {

            animator.SetTrigger("isPowerUp");
           

            // animator.SetBool("isPowerUp", false);


        }
    }


    

 


    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove *Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }


   



    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
           // ScreenController2.GetComponent<SceneController>().GameOver();
            
        

        }
    }
    */
   



}
