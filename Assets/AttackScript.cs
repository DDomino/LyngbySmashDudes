using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour  
{

    private GameObject Monster;
    public GameObject player;
    

    int numberClicks;

    // Start is called before the first frame update
    void Start()
    {
        Monster = GameObject.FindGameObjectWithTag("Monster");
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            numberClicks = player.GetComponent<MovementController>().noOfClicks;
            if (numberClicks == 1||numberClicks == 2)
            {
                Monster.GetComponent<playerHP>().takingDamge();
            }if(numberClicks == 3)
            {
                Monster.GetComponent<playerHP>().forceHit(player.GetComponent<CharacterController2D>().m_FacingRight);

              

            }

        }
 
   }



       
       
   
}
