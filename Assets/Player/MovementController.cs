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

    public int noOfClicks;
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
            StartCoroutine("comboWait");

         }

        if (noOfClicks == 2)
        {
            animator.SetInteger("noOfClicks", noOfClicks);
        }


        if (noOfClicks == 3)
        {
         
            animator.SetInteger("noOfClicks", noOfClicks);
            canClick = false;

        }
    

    }

    IEnumerator comboWait()
    {

        
        yield return new WaitForSecondsRealtime(0.8f);
        noOfClicks = 0;
        animator.SetInteger("noOfClicks", 0);
        canClick = true;


    }


    public void ComboCheck()
    {
        
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
