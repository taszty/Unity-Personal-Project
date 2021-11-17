using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{

    // Variables
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject pauseMenu2UI;
    [SerializeField] private GameObject optionMenuUI;
    [SerializeField] private bool isPaused;

    private void Update()
    {
        // Trigger for the pause menu when pressing escape
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        // Activates menu
        if (isPaused)
        {
            ActivateMenu();
        }
        // Deactivates menu
        else
        {
            DeactivateMenu();
        }

        // Fixes pause menu when player exits pause via option screen
        if (optionMenuUI.activeInHierarchy == false)
        {
            if (pauseMenuUI.activeInHierarchy == true)
            {
                pauseMenu2UI.SetActive(true);
            }
        }

    }

    // Method for activating menu
    public void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Method for deactivating menu
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false);
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Method for quit button
    public void QuitGame()
    {
        // Quits application
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
