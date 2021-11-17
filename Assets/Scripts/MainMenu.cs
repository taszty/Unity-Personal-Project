using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to progress scene from main menu  when pressing "play" button
    public void PlayGame ()
    {
        // Causes next level in scene que to be loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Method for "quit game" button
    public void QuitGame ()
    {
        // Quits application
        Debug.Log("QUIT!");
        Application.Quit();
    }


}
