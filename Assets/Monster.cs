using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    int layerMask = 1 << 10;


    public float MovementSpeed;
    private float distance = 2f;

    private bool movingRIght;
    Vector2 direction;

    public Transform GroundDetection;
    public Transform monster;


    public Animator animator;

    

    // RaycastHit2D findEnemy = Physics2D.Raycast(GroundDetection.position, direction, distance);

    private void Start()
    {
        movingRIght = true;
        InvokeRepeating("LookForPlayer", 1 , 0.5f);
       // layerMask = ~layerMask;

    }


    private void Update()
    {
        transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
        animator.SetFloat("MovementSpeed", MovementSpeed);
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, distance, 1<<8);
        

        Debug.Log(groundInfo.collider);
            if(groundInfo.collider == false)
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




    public void LookForPlayer()
    {
        Debug.Log("Tjek");
        RaycastHit2D FindEnemyFront = Physics2D.Raycast(GroundDetection.position, direction, distance, layerMask);
        RaycastHit2D findEnemyBack = Physics2D.Raycast(monster.position, -direction, distance, layerMask);
       
        
        if (FindEnemyFront.collider == true)
        {
            Debug.DrawRay(monster.position, direction, Color.red, 1f);
            Debug.Log("you are Infront");
            StartCoroutine("Chase");

        }
        if(findEnemyBack.collider == true)
        {
            Debug.DrawRay(monster.position, -direction, Color.red, 1f);
            Debug.Log("You are Behind me");

        }
    }


    IEnumerator Chase() {


        MovementSpeed = MovementSpeed+1;
        yield return new WaitForSecondsRealtime(0.5f);
        MovementSpeed = MovementSpeed - 1;
       
    }

    
}
