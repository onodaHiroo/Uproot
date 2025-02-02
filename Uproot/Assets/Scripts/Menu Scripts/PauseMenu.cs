using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pauseGame;
    public GameObject pauseGameMenu;
    public GameObject pauseButton;
    public GameObject pauseButtonsMenu;
    public GameObject pauseSettingsMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseGame)
            {
                Resume();
                FindObjectOfType<CursorScript>().SetCelCursor();
            }
            else
            {
                Pause();
                FindObjectOfType<CursorScript>().SetNullCursor();
            }
        }
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        pauseButton.SetActive(true);
        pauseButtonsMenu.SetActive(true);
        pauseSettingsMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;

        
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        pauseGame = true;

        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
