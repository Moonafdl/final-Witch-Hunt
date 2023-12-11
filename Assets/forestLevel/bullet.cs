using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 5;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enemySpellDamage enemy = hitInfo.GetComponent<enemySpellDamage>();
        if(enemy != null )
        {
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
