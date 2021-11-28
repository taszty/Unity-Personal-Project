using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketUI : MonoBehaviour
{
    // Variables
    [SerializeField] private Text messageUI;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] bool hasInteracted;

    private void Start()
    {
        // Sets value to false on start
        bool hasInteracted = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Enables UI on collider entry
        if (other.CompareTag("Player"))
        {
            messageUI.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Disables UI on collider exit
        if (other.CompareTag("Player"))
        {
            messageUI.enabled = false;
        }
    }

    private void Update()
    {
        // Disables UI upon pausing
        if (pauseMenu.activeSelf == true)
        {
            messageUI.enabled = false;
        }
    }
}