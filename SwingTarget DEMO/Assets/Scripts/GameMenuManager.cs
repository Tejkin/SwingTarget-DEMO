using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private Timer linkedTimerManager;

    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject endMenu;
    public TextMeshProUGUI timerText;

    [Header("Input")]
    public InputActionProperty showButton;

    [Header("XRRay Interactor")]

    [Header("Left Controller")]
    public GameObject leftMenuLineRenderer;
    public GameObject leftHandModel;
    public GameObject leftSwing;

    [Header("Right Controller")]
    public GameObject rightMenuLineRenderer;
    public GameObject rightSaber;
    public GameObject rightHandModel;
    public GameObject rightSwing;

    private bool paused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPerformedThisFrame())
        {
            if (!paused)
            {
                Pause();
                
            }
            else if (paused)
            {
                Resume();
                
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = true;

        // Deactivate model
        leftMenuLineRenderer.SetActive(true);
        leftHandModel.SetActive(false);
        leftSwing.SetActive(false);

        rightSwing.SetActive(false);
        rightSaber.SetActive(false);
        rightMenuLineRenderer.SetActive(true);
        rightHandModel.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = false;

        //Reactivate model
        leftMenuLineRenderer.SetActive(false);
        rightSaber.SetActive(true);
        leftHandModel.SetActive(true);
        leftSwing.SetActive(true);

        rightSwing.SetActive(true);

        rightMenuLineRenderer.SetActive(false);
        rightHandModel.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Finish()
    {
        paused = true;
        Time.timeScale = 0;
        endMenu.SetActive(!endMenu.activeSelf);
        float timer = linkedTimerManager.ReturnTimer();
        timerText.text = timer.ToString("0.00") + " seconds";
        leftMenuLineRenderer.SetActive(true);
        leftHandModel.SetActive(false);
        leftSwing.SetActive(false);

        rightSwing.SetActive(false);
        rightSaber.SetActive(false);
        rightMenuLineRenderer.SetActive(true);
        rightHandModel.SetActive(false);
    }
}

