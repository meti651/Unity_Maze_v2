using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public bool GameIsPaused = false;
    public string QuitGameName;

    public GameObject PauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitToMainMenu()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(QuitGameName);
    }
}
