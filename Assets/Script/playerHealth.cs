using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;

    public healthBar healthbar;

    public GameManagerScript gameManager;
    private bool isDead;

    void Start()
    {
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if(health <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthbar.SetHealth(health);

        
    }
}
