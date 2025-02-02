using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber + 1);
    }

    public void Quit()
    {
        Debug.Log("You exited the game");
        Application.Quit();
    }
}
