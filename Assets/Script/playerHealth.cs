using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;

    public healthBar healthbar;
    void Start()
    {
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthbar.SetHealth(health);

        
    }
}
