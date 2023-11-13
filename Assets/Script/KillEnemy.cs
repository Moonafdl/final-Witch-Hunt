using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody component
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Assigning the Rigidbody component
    }

    void Update()
    {
        if (isJumping && rb.velocity.y == 0)
        {
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isJumping)
        {
            // Enemy defeated
            Destroy(collision.gameObject); // Or deactivate the enemy gameObject
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
