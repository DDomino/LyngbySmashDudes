using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private GameObject player;
    private bool facing;
    public float speed = 4.0f;
    private GameObject Monster;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Monster = GameObject.FindGameObjectWithTag("Monster");
        Destroy(this.gameObject, 2f);
        
       // facing = player.GetComponent<CharacterController2D>().m_FacingRight;

    //    if (facing == true)
    //    {
    //        shootRight();


    //    }
    //    else
    //    {
    //        shootLeft();
    //    }


    //}

    //public void shootLeft()
    //{
    //    transform.Translate(Vector2.left * speed * Time.deltaTime);

    //}

    //public void shootRight()
    //{
    //    transform.Translate(Vector2.right * speed * Time.deltaTime);
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        facing = player.GetComponent<CharacterController2D>().m_FacingRight;
        if (collision.CompareTag("Monster"))
        {         
            Monster.GetComponent<playerHP>().forceHit(facing);
            Destroy(gameObject);

        }
        if (collision.CompareTag("vase")|| collision.CompareTag("ArenaEdge"))
        {
            Destroy(gameObject);
        }
    }
}
