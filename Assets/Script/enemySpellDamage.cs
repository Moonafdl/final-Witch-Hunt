using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpellDamage : MonoBehaviour
{
    public int health = 20;
    //public GameObject deathEffect;
    
    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        } 
    }

    void Die()
    {
        //Instantiate(deathEffect,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
