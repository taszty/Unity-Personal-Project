using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalUI : MonoBehaviour
{
    // Variables
    [SerializeField] private Image noteImage;
    [SerializeField] private GameObject pauseMenu;

    void OnTriggerEnter(Collider other)
    {
        // Enables UI on collider entry
        if (other.CompareTag("Player"))
        {
            noteImage.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Disables UI on collider exit
        if (other.CompareTag("Player"))
        {
            noteImage.enabled = false;
        }
    }

    private void Update()
    {
        // Disables UI upon pausing
        if (pauseMenu.activeSelf == true)
        {
            noteImage.enabled = false;
        }
    }
}