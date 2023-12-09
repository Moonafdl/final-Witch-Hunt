using System.Collections;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float dirX = 0f;

    // Animation
    private SpriteRenderer sprite;
    private Animator anim;
    private enum MovementState { idle, running }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0f;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>(); // Initialize the sprite variable
    }

    void Update()
    {
        
        // Get input from the player
        
        moveInput = new Vector2(dirX, Input.GetAxis("Vertical"));

        
    }

    void FixedUpdate()
    {
        // Move and rotate the character
        MoveCharacter();
        RotateCharacter();
    }

    void MoveCharacter()
    {
        // Normalize the input vector to ensure consistent movement speed in all directions
        moveInput.Normalize();

        // Move the character based on input
        Vector2 movement = moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void RotateCharacter()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}

















//Vector2 moveDelta = new Vector2(moveX, moveY);

//Flip the player according to the move direction
//if (moveDelta.x > 0)
//{
//transform.localScale = new Vector3(0.5f, 0.5f, 1);
//}
//else if (moveDelta.x < 0)
//{
//transform.localScale = new Vector3(-0.5f, 0.5f, 1);
//}