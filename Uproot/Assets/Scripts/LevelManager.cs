using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] enemies;


    [SerializeField] private bool allEnemiesAreDeadCheck;
    [SerializeField] private GameObject exit;
    public TextMeshProUGUI levelCompletedTMPUGUI;

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        exit = GameObject.Find("ExitFromLvl");
    }

    private void Update()
    {
        if (AllEnemiesAreDead())
        {
            allEnemiesAreDeadCheck = true;
            levelCompletedTMPUGUI.gameObject.SetActive(true);

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool AllEnemiesAreDead()
    {
       for (int x = 0; x < enemies.Length; x++)
        {
            if (enemies[x] != null)
            {
                if (enemies[x].tag != "Dead")
                {
                    return false;
                }
            }
            else if (enemies == null)
            {
                return true;
            }
        }
       return true;
    }
}
