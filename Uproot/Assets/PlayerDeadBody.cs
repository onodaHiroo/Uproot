using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadBody : MonoBehaviour
{
    public bool isDead;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Pressed 'R'");
            GameObject levelManager = GameObject.FindGameObjectWithTag("LevelManager");

            if (levelManager != null)
            {
                levelManager.GetComponent<LevelManager>().Restart();
                isDead = false;
            }
        }
    }
}
