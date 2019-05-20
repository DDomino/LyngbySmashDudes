using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakStuff : MonoBehaviour
{

    public GameObject brokenbits;
    public bool collideWithBits;

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
            BreakIt();

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Projectile")
            BreakIt();

    }

    //https://www.youtube.com/watch?v=uBqzkfUL6_M

    public void BreakIt()
    {
        Destroy(this.gameObject);
        GameObject broke = (GameObject)Instantiate(brokenbits, transform.position, Quaternion.identity);

        if (!collideWithBits)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("player"), LayerMask.NameToLayer("BrokenBits"));

        }

        foreach (Transform child in broke.transform)
        {


            child.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(5f, 10f));
        }

        Destroy(broke, 0.5f);


    }


}