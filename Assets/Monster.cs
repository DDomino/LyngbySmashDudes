using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Animator animator;

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
    private float AttackDistance = 0.2f;
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
    






    void AttackAI()
    {
        

        if(Vector2.Distance(player.transform.position, transform.position) < AttackDistance && canClick == true)

        {
            Debug.Log("Enter Attack");
            MovementSpeed = 0;
            if (noOfClicks == 0)
            {
                StartCoroutine("comboWait");
                Debug.Log("Enter Attack step 1");

            }
            if (noOfClicks == 1)
            {
                Debug.Log("Enter Attack step 2");
                animator.SetInteger("noOfClicks", noOfClicks);
                StartCoroutine("comboWait");

            }
            
            if (noOfClicks == 2)
            {
                Debug.Log("Enter Attack step 3");
                StartCoroutine("comboWait");
                animator.SetInteger("noOfClicks", noOfClicks);
               
            }
            if (noOfClicks >= 3)
            {
                Debug.Log("Enter Attack step 4");
                noOfClicks = 0;
                canClick = false;
                animator.SetInteger("noOfClicks", noOfClicks);
                Moving = true;
            }

        }
       

    }
   IEnumerator comboWait()
    {
        
        yield return new WaitForSecondsRealtime(0.5f);
        if (Vector2.Distance(player.transform.position, transform.position) < AttackDistance && canClick == true)
        {
            noOfClicks++;
            AttackAI();
        }
        else
        {
            noOfClicks = 0;
            Moving = true;
            canClick = true;
        }
            
    }

    




    public void LookForPlayer()
    {
        RaycastHit2D FindEnemyFront = Physics2D.Raycast(FrontDetection.position, direction, DetectionDistance, layerMask);
        RaycastHit2D findEnemyBack = Physics2D.Raycast(BackDetection.position, -direction, DetectionDistance, layerMask);


        if (Vector2.Distance(player.transform.position, transform.position) < AttackDistance)
        {
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
                }
                else
                {

                    transform.eulerAngles = new Vector3(0, 0, 0);
                    direction = Vector2.right;
                    movingRIght = true;
                }
            }

        }

        /*
        if (Vector2.Distance(player.transform.position, transform.position) < AttackDistance)

        {
            Moving = false;
            AttackAI();
        }
        */
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
                }
                else
                {

                    transform.eulerAngles = new Vector3(0, 0, 0);
                    direction = Vector2.right;
                    movingRIght = true;
                }
            }

        }

       
    }



    IEnumerator Chase() {


        MovementSpeed = MovementSpeed*1.10f;
        yield return new WaitForSecondsRealtime(0.5f);
        MovementSpeed = MovementSpeed * 0.9f;
       
    }

    
}
