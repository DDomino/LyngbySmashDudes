using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject player;
    private bool facing;
    public float speed = 4.0f;



    // Start is called before the first frame update
    void Start()
    {
        facing = player.GetComponent<CharacterController2D>().m_FacingRight;

        if (facing == true)
        {
            shootRight();


        }
        else
        {
            shootLeft();
        }


    }

    public void shootLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    public void shootRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
