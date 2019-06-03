﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Monster : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI PlayerIndicator;

    //Movement Variables
    Vector2 direction;
    public float MovementSpeed = 3;
    private bool movingRIght;
    bool Moving;



    //Detection Variables
    int layerMask = 1 << 10;
    private float DetectionDistance = 2f;
    public Transform FrontDetection;
    public Transform BackDetection;
    private GameObject player;


   
    //Attack Variables
    private float AttackDistance = 0.3f;
    bool Attacking;


    public int noOfClicks;
    bool canClick;
    public GameObject fist;





    // RaycastHit2D findEnemy = Physics2D.Raycast(GroundDetection.position, direction, distance);

    private void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player");



        //Moving Start Settings
        movingRIght = true;
        Moving = true;



        //Attacking Start Settings
        Attacking = false;
        noOfClicks = 0;
        canClick = true;
       



        //Start detection method, and run every 0.5second
        InvokeRepeating("LookForPlayer", 1 , 0.5f);
        InvokeRepeating("AttackAI", 1, 0.01f);
    }


    private void Update()
    {


     if(Moving == true)
        {
            MoveAI();
        }
           
      
      

    }
    






    public void AttackAI()
    {
    
        if (Vector2.Distance(player.transform.position, transform.position) < AttackDistance && canClick == true)
   
        {

            animator.SetFloat("MovementSpeed", MovementSpeed);
            MovementSpeed = 0;
            Debug.Log("Enter Attack");
           
            if (noOfClicks == 0)
            {
                StartCoroutine("comboWait");
                Debug.Log("Enter Attack step 1");
                

            }
            if (noOfClicks == 1)
            {
                Debug.Log("Enter Attack step 2");
                animator.SetInteger("noOfClicks", noOfClicks);
                player.GetComponent<playerHP>().takingDamge();
                StartCoroutine("comboWait");
                

            }
            
            if (noOfClicks == 2)
            {
                Debug.Log("Enter Attack step 3");
                player.GetComponent<playerHP>().takingDamge();
                StartCoroutine("comboWait");
              
                animator.SetInteger("noOfClicks", noOfClicks);
            

            }
            if (noOfClicks >= 3)
            {
                Debug.Log("Enter Attack step 4");
                player.GetComponent<playerHP>().forceHit( GetComponent<Monster>().movingRIght);
                noOfClicks = 0;
                animator.SetInteger("noOfClicks", noOfClicks);
                canClick = false;
                Moving = true;
               
                
          


            }

        }
       

    }
   IEnumerator comboWait()
    {
        
        yield return new WaitForSecondsRealtime(1f);
        if (Vector2.Distance(player.transform.position, transform.position) < AttackDistance && canClick == true)
        {
            noOfClicks++;
            AttackAI();
        }
        else
        {
            noOfClicks = 0;
            animator.SetInteger("noOfClicks", noOfClicks);
            Moving = true;
            canClick = true;

        }
            
    }

    




    public void LookForPlayer()
    {
        RaycastHit2D FindEnemyFront = Physics2D.Raycast(FrontDetection.position, direction, DetectionDistance, layerMask);
        RaycastHit2D findEnemyBack = Physics2D.Raycast(BackDetection.position, -direction, DetectionDistance, layerMask);


      
        
            MovementSpeed = 3;
            canClick = true;
            if (FindEnemyFront.collider == true)
            {
                Debug.DrawRay(BackDetection.position, direction, Color.red, 1f);

                StartCoroutine("Chase");

            }
            if (findEnemyBack.collider == true)
            {
                Debug.DrawRay(BackDetection.position, -direction, Color.red, 1f);

                if (movingRIght == true)
                {

                    transform.eulerAngles = new Vector3(0, -180, 0);
                    direction = Vector2.left;
                    movingRIght = false;

                    Vector3 PIScale = PlayerIndicator.transform.localScale;
                    PIScale.x *= -1;
                    PlayerIndicator.transform.localScale = PIScale;
            }
                else
                {

                    transform.eulerAngles = new Vector3(0, 0, 0);
                    direction = Vector2.right;
                    movingRIght = true;

                    Vector3 PIScale = PlayerIndicator.transform.localScale;
                    PIScale.x *= -1;
                    PlayerIndicator.transform.localScale = PIScale;
            }
            }

        

       
    }



    void MoveAI()
    {


        if (Vector2.Distance(player.transform.position, transform.position) > AttackDistance)
        {
            
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            animator.SetFloat("MovementSpeed", MovementSpeed);
            RaycastHit2D groundInfo = Physics2D.Raycast(FrontDetection.position, Vector2.down, DetectionDistance, 1 << 8);


            Debug.Log(groundInfo.collider);
            if (groundInfo.collider == false)
            {

                Debug.Log("Ground info is false");
                if (movingRIght == true)
                {

                    transform.eulerAngles = new Vector3(0, -180, 0);
                    direction = Vector2.left;
                    movingRIght = false;

                    Vector3 PIScale = PlayerIndicator.transform.localScale;
                    PIScale.x *= -1;
                    PlayerIndicator.transform.localScale = PIScale;
                }
                else
                {

                    transform.eulerAngles = new Vector3(0, 0, 0);
                    direction = Vector2.right;
                    movingRIght = true;

                    Vector3 PIScale = PlayerIndicator.transform.localScale;
                    PIScale.x *= -1;
                    PlayerIndicator.transform.localScale = PIScale;
                }
            }

        }
        if (Vector2.Distance(player.transform.position, transform.position) < AttackDistance)
        {
            Moving = false;
            AttackAI();
        }

       
    }



    IEnumerator Chase() {


        MovementSpeed = MovementSpeed*1.10f;
        yield return new WaitForSecondsRealtime(0.5f);
        MovementSpeed = MovementSpeed * 0.9f;
       
    }

    
}
