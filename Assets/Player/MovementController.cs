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

    int noOfClicks;
    bool canClick;


    private void Start()
    {
        noOfClicks = 0;
        canClick = true;
    }



    public void SpeedBoost(float amount)
    {
        runSpeed += amount;
    }

void Update()
    {

        if (Input.GetMouseButtonDown(0)) { ComboStarter(); }

     animator.SetFloat("MovementSpeed", Mathf.Abs(horizontalMove));

        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
         //   animator.SetBool("isJumping", true);

        }

    }


    void ComboStarter()
    {
        if (canClick)
        {
            noOfClicks++;
        }
        if (noOfClicks == 1) {
            animator.SetInteger("noOfClicks", noOfClicks);
           
           
        }
        if (noOfClicks == 2)
        {
            canClick = true;
            animator.SetInteger("noOfClicks", noOfClicks);
            Debug.Log("Punch 2");
        }
        if (noOfClicks == 3)
        {
            
            animator.SetInteger("noOfClicks", noOfClicks);
            Debug.Log("Punch 3");
            noOfClicks = 0;
            
        }

    }


    public void ComboCheck()
    {
        canClick = false;

        

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
