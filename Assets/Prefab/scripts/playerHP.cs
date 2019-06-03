using UnityEngine;

public class playerHP : MonoBehaviour
{

    //Defender is the object getting hit. 
    //The defender is the object carrying the script, as the defender object is adding damaget to itself
    public Rigidbody2D Defender;

    public float hp = 0;
    

   


    public void takingDamge()
    {
        //Add 10% damage to defender
        hp +=10;
    }



    //Kockback calculating. This method adds the Knockback effect to the defending target.
    //The direction of the force is determined by the Bool from the attackers movement
    //True == right, False == Left
    public void forceHit(bool AttackersFacing)
    {

        //If the Attacker is facing true. Add Force Up and right.
        if(AttackersFacing == true)
        {
            
            hp += 5;
    
            Defender.AddForce(transform.up * hp);
            Defender.AddForce(transform.right * hp);
        } else
        //If the attacker is facing false. add force Up and Left
        {

            // -Transfer.right = left. Or ANTI Right. 
            hp += 5;
            
            Defender.AddForce(transform.up * hp);
            Defender.AddForce(-transform.right * hp);

        }
    }
}
