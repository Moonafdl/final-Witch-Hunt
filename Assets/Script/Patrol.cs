using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 5f;

    private float originalX;
    private int direction = 1;

    void Start()
    {
        originalX = transform.position.x;
    }

    void Update()
    {
        PatrolMovement();
    }

    void PatrolMovement()
    {
        // Move the enemy horizontally
        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);

        // Check if the enemy has reached the patrol distance
        if (Mathf.Abs(transform.position.x - originalX) >= patrolDistance)
        {
            // Change direction when reaching the patrol distance
            direction *= -1;

            // Flip the enemy sprite to face the new direction
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}