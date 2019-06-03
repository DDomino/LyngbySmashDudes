using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killPlayer : MonoBehaviour
{

    public float monsterOutCount = 0;
    public float stage = 0;
    



    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

     
    
        {
            if (other.gameObject.CompareTag("Player") )
            {
                stage = 2;
                SceneManager.LoadScene("youLost");
                

            }

           
            if (other.gameObject.CompareTag("Monster")&& stage ==1)
            {
                SceneManager.LoadScene("stage 3");
               
            }
            if (other.gameObject.CompareTag("Monster") )
            {
                monsterOutCount++;
            }


            if (other.gameObject.CompareTag("Monster") && monsterOutCount == 2)
            {
                SceneManager.LoadScene("YouWOn");
            }
        }
    }

    

   
}
