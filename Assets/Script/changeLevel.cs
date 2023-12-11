using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class changeLevel : MonoBehaviour
{

    public string levelToLoad;
    private Animator anim;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //anim.SetTrigger("portal");
        if (other.gameObject.CompareTag("player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
