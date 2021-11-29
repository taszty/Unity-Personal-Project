using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KatanaUI : MonoBehaviour
{
    // Variables
    [SerializeField] private Text kmessageUI;
    [SerializeField] private GameObject pauseMenu;

    void OnTriggerEnter(Collider other)
    {
        // Enables UI on collider entry
        if (other.CompareTag("Player"))
        {
            kmessageUI.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Disables UI on collider exit
        if (other.CompareTag("Player"))
        {
            kmessageUI.enabled = false;
        }
    }

    private void Update()
    {
        // Disables UI upon pausing
        if (pauseMenu.activeSelf == true)
        {
            kmessageUI.enabled = false;
        }
    }
}
