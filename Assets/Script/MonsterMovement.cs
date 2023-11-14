using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public Transform[] patrolPoint;
    public float moveSpeed;
    public int patrolDestination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    //animation
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        if (playerTransform.position.x < transform.position.x)
        {
            // Player is to the left, so face right initially
            transform.localScale = new Vector3(0.7907117f, 0.7734414f, 1);
        }
        else
        {
            // Player is to the right, so face left initially
            transform.localScale = new Vector3(-0.7907117f, 0.7734414f, 1);
        }

    }


    // Update is called once per frame
    void Update()
    {

        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(-0.7907117f, 0.7734414f, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(0.7907117f, 0.7734414f, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {

            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }

            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoint[0].position) < .2f)
                {
                    transform.localScale = new Vector3(0.7907117f, 0.7734414f, 1);
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoint[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-0.7907117f, 0.7734414f, 1);
                    patrolDestination = 0;
                }
            }
        }



    }
}
