using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{

    public GameObject player;
    public float hp = 30;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void takingDamge()
    {
        hp+=10;
    }

    public void forceHit(bool b)
    {

        if(b == true)
        {
            hp += 5;
            rb.AddForce(transform.up * hp);
            rb.AddForce(transform.right * hp);
        } else
        {
            hp += 5;
            rb.AddForce(transform.up * hp);
            rb.AddForce(-transform.right * hp);
        }
    }
}
