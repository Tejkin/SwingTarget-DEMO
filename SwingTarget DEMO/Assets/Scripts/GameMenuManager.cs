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

    [Header("XRRay")]
    public LineRenderer menuLineRenderer;
    public GameObject saber;
    public GameObject hand;

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
                menuLineRenderer.enabled = true;
                saber.SetActive(false);
                hand.SetActive(false);
            }
            else if (paused)
            {
                Resume();
                menuLineRenderer.enabled = false;
                saber.SetActive(true);
                hand.SetActive(true);
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = false;
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
    }
}

