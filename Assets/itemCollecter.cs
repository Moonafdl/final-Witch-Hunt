using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class itemCollecter : MonoBehaviour
{
    //varibales
    [SerializeField] private Text itemsText;

    private int items = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //keeping count of all the items collected when collided with
        if (collision.gameObject.CompareTag("items"))
        {
            Destroy(collision.gameObject);
            items++;
            itemsText.text = "Items: " + items;
        }
    }

}
