using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class miniGameChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextLevel()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene (assuming scenes are arranged in the build settings in the correct order)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
