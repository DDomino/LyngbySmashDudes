using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{

    public CharacterController2D controller;

    float horizontalMove = 0f;
    bool jump = false;
    public float runSpeed = 40f;
    public Animator animator;
 



    private bool Hunt = false;
    private GameObject Player;


    void Start()
    {
      
        Player = GameObject.FindGameObjectWithTag("Player");
        

    }

    // Update is called once per frame
    void Update()
    {

       // if (Input.GetMouseButtonDown(0)) { ComboStarter(); }

        animator.SetFloat("MovementSpeed", Mathf.Abs(horizontalMove));

     
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
       
    }






}
