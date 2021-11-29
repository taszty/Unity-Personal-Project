using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrateUI : MonoBehaviour
{
    // Variables
    [SerializeField] private Text cmessageUI;
    [SerializeField] private GameObject pauseMenu;

    void OnTriggerEnter(Collider other)
    {
        // Enables UI on collider entry
        if (other.CompareTag("Player"))
        {
            cmessageUI.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Disables UI on collider exit
        if (other.CompareTag("Player"))
        {
            cmessageUI.enabled = false;
        }
    }

    private void Update()
    {
        // Disables UI upon pausing
        if (pauseMenu.activeSelf == true)
        {
            cmessageUI.enabled = false;
        }
    }
}
