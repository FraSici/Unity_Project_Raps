using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public Button resumeButton, mainMenuButton, inventoryButton, SaveButton;
    

    public GameObject player;
    public bool usingPausePanel;
    public string scene2Load;

    [Header("Input System")]
    [SerializeField] public GameControls controls;

    private void Awake()
    {
        controls = new GameControls();

    }
    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Submit_Pause.performed += ctx =>
        {
            controls.Player.Disable();
            OpenPauseMenu();
            controls.Pause_Menu.Enable();
        };

        controls.Pause_Menu.Exit_Pause.performed += ctx =>
        {
            controls.Pause_Menu.Disable();
            ExitPauseMenu();
            controls.Player.Enable();
        };
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void OpenPauseMenu()
    {

        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        usingPausePanel = true;
        player.SetActive(false);
        Debug.Log("Open Pause Menu");
    }

    private void ExitPauseMenu()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        usingPausePanel = false;
        player.SetActive(true);
        Debug.Log("Start button pressed: exit pause menu");
    }

    void Start()
    {
        //Set-up pause and inventory menus to inactive as game starts
        isPaused = false;
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        usingPausePanel = false;

        //Add listeners to button click events
/*        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(Quit2Main);
        inventoryButton.onClick.AddListener(SwitchPanels);
 */       
    }

    void Update()
    {
/*        if (Input.GetButtonDown("Submit"))
        {
            ResumeStartButton();
        }
        else if (isPaused)
        {
            if (Input.GetButtonDown("MenuSelect_A") && resumeButton.onClick != null)
            {
                Debug.Log("Resume");
                Resume();
            }
            else if (Input.GetButtonDown("MenuSelect_A") && mainMenuButton.onClick != null)
            {
                Debug.Log("Q2M");
                Quit2Main();
            }
            else if (Input.GetButtonDown("MenuSelect_A") && inventoryButton.onClick != null)
            {
                Debug.Log("Inventory");
                SwitchPanels();
            }
        }
*/
    }

    public void Resume()
    {
        if (isPaused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            usingPausePanel = false;
            player.SetActive(true);
            Debug.Log("In resume");

        }
    }
    public void ResumeStartButton()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            usingPausePanel = true;
            player.SetActive(false);
            Debug.Log("In resumeStart");
        }
        else
        {
            pausePanel.SetActive(false);
            Debug.Log("Resume game with start button");
            Time.timeScale = 1f;
            usingPausePanel = false;
            player.SetActive(true);
        }

    }

    public void Quit2Main()
    {
        SceneManager.LoadScene(scene2Load);
        Time.timeScale = 1f;
        Debug.Log("In Q2M");
    }

    public void SwitchPanels()
    {
        usingPausePanel = !usingPausePanel;
        if (usingPausePanel)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            Debug.Log("Switch panels");
            inventoryPanel.SetActive(false);
            Debug.Log("Is pause panel active? " + pausePanel.activeSelf);

        }
        else
        {
            Debug.Log("Back to pause");
            pausePanel.SetActive(false);
            inventoryPanel.SetActive(false);
            inventoryPanel.SetActive(true);
        }
    }
}
