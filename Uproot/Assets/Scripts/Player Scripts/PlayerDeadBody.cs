using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeadBody : MonoBehaviour
{
    public bool isDead;
    private GameObject restartText;

    private void Start()
    {
        restartText = GameObject.FindWithTag("RestartText");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restartText.SetActive(false);
            Debug.Log("Pressed 'R'");
            GameObject levelManager = GameObject.FindGameObjectWithTag("LevelManager");

            if (levelManager != null)
            {
                levelManager.GetComponent<LevelManager>().Restart();
                isDead = false;
            }
            restartText.GetComponent<Text>().enabled = true;
        }
    }
}
