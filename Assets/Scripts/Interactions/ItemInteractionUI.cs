using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemInteractionUI : MonoBehaviour
{
    // Variables
    [Header("Menu UI")]
    [Space]
    [SerializeField] private GameObject pauseMenu;
    [Space]
    [SerializeField] private Text foundItems;

    [Header("Message UI Text")]
    [Space]
    [SerializeField] private Text firstBucketUI;
    [SerializeField] private Text secondBucketUI;
    [Space]
    [SerializeField] private Text firstSmallboxUI;
    [SerializeField] private Text secondSmallboxUI;
    [Space]
    [SerializeField] private Text firstToolboxUI;
    [SerializeField] private Text secondToolboxUI;
    [Space]
    [SerializeField] private Text firstAxeUI;
    [SerializeField] private Text secondAxeUI;
    [Space]
    [SerializeField] private Text firstDoorUI;

    [Header("Booleans")]
    [Space]
    [SerializeField] private bool hasKey;
    [SerializeField] private Text hasKeyUI;
    [Space]
    [SerializeField] private bool hasScrewdriver;
    [SerializeField] private Text hasScrewdriverUI;
    [Space]
    [SerializeField] private bool hasHammer;
    [SerializeField] private Text hasHammerUI;
    [Space]
    [SerializeField] private bool hasAxe;
    [SerializeField] private Text hasAxeUI;

    private void Start()
    {
        // Sets value on start
        foundItems.enabled = true;
        hasKey = false;
        hasScrewdriver = false;
        hasHammer = false;
        hasAxe = false;
        // Launch custom update coroutine
        InvokeRepeating("CustomUpdate", 1f, .5f);
    }

    private void CustomUpdate()
    {
        // Disables UI on pause
        if (pauseMenu.activeSelf == enabled)
        {
            hasKeyUI.enabled = false;
            hasScrewdriverUI.enabled = false;
            hasHammerUI.enabled = false;
            hasAxeUI.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Code for bucket trigger
        if (other.tag == "Bucket")
        {
            if (hasKey)
            {
                // Enables second message after obtaining item
                secondBucketUI.enabled = true;
                hasKeyUI.enabled = true;
            }
            else
            {
                // Enables UI on collider entry
                firstBucketUI.enabled = true;

                // set bool to true
                hasKey = true;
            }
        }

        // Code for small box trigger
        if (other.tag == "Smallbox")
        {
            if (hasKey && hasScrewdriver)
            {
                // Enables UI on collider entry
                secondSmallboxUI.enabled = true;
                hasScrewdriverUI.enabled = true;
            }
            else if (hasKey)
            {
                // Enables UI on collider entry
                firstSmallboxUI.enabled = true;
                // set bool to true
                hasScrewdriver = true;
            }
            else
            {
                // Enables UI on collider entry
                firstSmallboxUI.enabled = true;
            }
        }

        // Code for toolbox trigger
        if (other.tag == "Toolbox")
        {
            if (hasScrewdriver && hasHammer)
            {
                // Enables second message after obtaining item
                secondToolboxUI.enabled = true;
                hasHammerUI.enabled = true;
            }
            else if (hasScrewdriver)
            {
                // Enables UI on collider entry
                firstToolboxUI.enabled = true;
                // set bool to true
                hasHammer = true;
            }
            else
            {
                // Enables UI on collider entry
                firstToolboxUI.enabled = true;
            }
        }

        // Code for axe trigger
        if (other.tag == "Axe")
        {

            if (hasHammer && hasAxe)
            {
                // Enables second message after obtaining item
                secondAxeUI.enabled = true;
                // Break glass covering the axe
                Destroy(GameObject.FindGameObjectWithTag("AxeGlass"));
                hasAxeUI.enabled = true;
            }
            else if (hasHammer)
            {
                // Enables UI on collider entry
                firstAxeUI.enabled = true;
                // set bool to true
                hasAxe = true;
            }
            else
            {
                // Enables UI on collider entry
                firstAxeUI.enabled = true;
            }
        }

        // Code for door trigger
        if (other.tag == "Door")
        {
            if (hasAxe)
            {
                // Triggers game ending
                Debug.Log("You beat the game!");
                FinishGame();
            }
            else
            {
                // Enables UI on collider entry
                firstDoorUI.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Disable all ui upon exiting a collider
        firstBucketUI.enabled = false;
        firstSmallboxUI.enabled = false;
        firstToolboxUI.enabled = false;
        firstAxeUI.enabled = false;
        firstDoorUI.enabled = false;

        secondBucketUI.enabled = false;
        secondSmallboxUI.enabled = false;
        secondToolboxUI.enabled = false;
        secondAxeUI.enabled = false;
    }

    // Method for beating the game
    public void FinishGame()
    {
        // Causes next level in scene que to be loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
