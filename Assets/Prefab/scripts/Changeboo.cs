using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeboo : MonoBehaviour
{


    public GameObject player;
    public GameObject AI;
    public GameObject vase;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
            player.GetComponent<playerPowerUp>().ActivatePowerUp();
        }

        if (Input.GetKeyDown("i"))
        {
            var VaseInst = Instantiate(vase, transform.position, Quaternion.Euler(new Vector2(5, 0)));
        }

        if (Input.GetKey("b"))
        {
            player.GetComponent<playerHP>().takingDamge();
        }
        if (Input.GetKey("k"))
        {
            AI.GetComponent<playerHP>().forceHit(player.GetComponent<CharacterController2D>().m_FacingRight);
           

        }
    }
}
