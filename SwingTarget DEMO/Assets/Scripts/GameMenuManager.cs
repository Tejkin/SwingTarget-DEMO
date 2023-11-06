using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty showButton;
    public bool paused = false;
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
        menu.SetActive(!menu.activeSelf);
        paused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(!menu.activeSelf);
        paused = false;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

