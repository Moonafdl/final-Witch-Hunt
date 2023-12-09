using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMove : MonoBehaviour
{

    public int sceneBuildingIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger entered");
        if(other.tag == "player")
        {
            SceneManager.LoadScene(sceneBuildingIndex, LoadSceneMode.Single);
        }
    }

}
