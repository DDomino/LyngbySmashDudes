using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killPlayer : MonoBehaviour
{

  
    public float stage = 0;
    



    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

     
    
        {
            if (other.gameObject.CompareTag("Player") )
            {
           
                SceneManager.LoadScene("youLost");
                

            }

           
            if (other.gameObject.CompareTag("Monster")&& stage ==1)
            {
                SceneManager.LoadScene("stage 3");
               
            }
           


            if (other.gameObject.CompareTag("Monster") && stage!=1)
            {
                
                SceneManager.LoadScene("YouWOn");
                
            }
        }
    }

    

   
}
