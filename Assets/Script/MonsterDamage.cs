using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    

    public int damage;
    public playerHealth pHealth;
    public playerMovement playerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }
            pHealth.TakeDamage(damage);
        }
    }

   
}

    
