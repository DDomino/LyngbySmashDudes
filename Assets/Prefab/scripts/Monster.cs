using System.Collections;

using UnityEngine;
using TMPro;


public class Monster : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI PlayerIndicator;

    //Movement Variables
    
    public float MovementSpeed = 3;
    private bool movingRIght; //Direction that the object is facing
    bool Moving; //Is the Object moving?



    //Detection Variables
    Vector2 direction; //Direction for the raycast
    int layerMask = 1 << 10; //Layser mask. 1 << 10 means that the layerMask looks at layer 10 (AKA: PlayerLayer)
    private float DetectionDistance = 2f; //The Distance used to determined how far the RayCast will "cast" from the monster. Used for Detecting player and ledges
    public Transform FrontDetection; //Front raycaster
    public Transform BackDetection; //Back Raycaster
    private GameObject player;


   
    //Attack Variables
    private float AttackDistance = 0.3f; //The distance the AI starts attacking from the player object
    bool Attacking; //Is the AI attacking or not.


    public int noOfClicks; //How many attacks is made, used to determine combos
    bool canClick; //Used to see if the can attack, to stop it from spamming
    public GameObject fist; //This fist hitbox





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


    void MoveAI()
    {

        //If the distance between the playerobject and this object is bigger than the attack distance
        if (Vector2.Distance(player.transform.position, transform.position) > AttackDistance)
        {


            //Always move facing direction
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            animator.SetFloat("MovementSpeed", MovementSpeed);

            //raycast form frontDetector against layer 8 (AKA "Ground" layer), returns bool
            RaycastHit2D groundInfo = Physics2D.Raycast(FrontDetection.position, Vector2.down, DetectionDistance, 1 << 8);


            //If the groundinfo is false (If the raycast does not hit a ground layer, AKA is at a ledge it will turn direction)
            if (groundInfo.collider == false)
            {

                
                if (movingRIght == true)
                {
                    //Turns object 180degree  around Y-axis
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    //Truns the raycast direction
                    direction = Vector2.left;
                    movingRIght = false;


                    //Flips the indicator "C1"
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

        //If Ai is within range of Player, stop moving and start attacking
        if (Vector2.Distance(player.transform.position, transform.position) < AttackDistance)
        {
            Moving = false;
            AttackAI();
        }


    }







    public void AttackAI()
    {
    
        if (Vector2.Distance(player.transform.position, transform.position) < AttackDistance && canClick == true)
   
        {
            //Stops running animations
            animator.SetFloat("MovementSpeed", MovementSpeed);
            MovementSpeed = 0;
        
           
            if (noOfClicks == 0)
            {
                canClick = false;
                StartCoroutine("comboWait");
            
            }
            if (noOfClicks == 1)
            {
                canClick = false;
                animator.SetInteger("noOfClicks", noOfClicks);
                player.GetComponent<playerHP>().takingDamge();
                StartCoroutine("comboWait");
                

            }
            
            if (noOfClicks == 2)
            {
                canClick = false;
                animator.SetInteger("noOfClicks", noOfClicks);
                player.GetComponent<playerHP>().takingDamge();
                StartCoroutine("comboWait");
              
                
            

            }
            if (noOfClicks >= 3)
            {
               
                player.GetComponent<playerHP>().forceHit( GetComponent<Monster>().movingRIght);
                noOfClicks = 0;
                animator.SetInteger("noOfClicks", noOfClicks);
                Moving = true;
               
                
          


            }

        }
       

    }

    /*Combo wait is a Coroutine that stops the AI from spamming its attacks.
     But also checks if it should continue to attack or move if the player 
     has run away and out fo attakc range*/
   IEnumerator comboWait()
    {
        
        yield return new WaitForSecondsRealtime(0.2f);
        if (Vector2.Distance(player.transform.position, transform.position) < AttackDistance)
        {
            noOfClicks++;
            AttackAI();
            canClick = true;
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
         

            if (FindEnemyFront.collider == true)
            {
                Debug.DrawRay(BackDetection.position, direction, Color.red, 1f);

                StartCoroutine("Chase");

            }
            if (findEnemyBack.collider == true)
            {
                Debug.DrawRay(BackDetection.position, -direction, Color.red, 1f);



                 //Flip again
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




    IEnumerator Chase() {


        MovementSpeed = MovementSpeed*1.10f;
        yield return new WaitForSecondsRealtime(0.5f);
        MovementSpeed = MovementSpeed * 0.9f;
       
    }

    
}
