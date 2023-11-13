using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<headCheck>())
        {

            Destroy(transform.parent.gameObject);
        }
    }
}
