using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killPlayer : MonoBehaviour
{

  

    private void OnTriggerEnter2D(Collider2D other)
    {
     
        {
            if (other.gameObject.CompareTag("Player") )
            {



                SceneManager.LoadScene("youLost");



            }

            if (other.gameObject.CompareTag("Projectile")){
                Destroy(other.gameObject); // this destroys the bullet

            }
            if (other.gameObject.CompareTag("Monster"))
            {
                SceneManager.LoadScene("YouWon");
            }
        }
    }

    

   
}
