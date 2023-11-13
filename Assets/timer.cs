using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    //variables
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    void Start()
    {
       
    }

    void Update()
    {

        //The timer for our game play
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
        }

        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds) ;
    }
}
