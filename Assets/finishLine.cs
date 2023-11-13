using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

//making a finish line that displays a "You win!" text
public class finishLine : MonoBehaviour
{
    //variables
    public Text winText; 

    private void Start()
    {       
        // Disable the WinText at the start of the game
        winText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //displaying the text only if the player collides with the pole
        if (collision.tag == "player")
        {
            // Enable the WinText and display the message
            winText.gameObject.SetActive(true);
            winText.text = "You Win!";
        }
    }
}
