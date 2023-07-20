using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    [Header("Check between scenes")]
    [SerializeField] private int nowSceneIndexInfo;
    [SerializeField] private int lastSceneIndexInfo;

    [Header("Timer")]
    [SerializeField] private float time;

    [Header("Score")]
    [SerializeField] public float scoreMultiplier;

    void Awake()
    {
        lastSceneIndexInfo = SceneManager.GetActiveScene().buildIndex;
        nowSceneIndexInfo = SceneManager.GetActiveScene().buildIndex;

        GameObject obj = GameObject.FindWithTag("LevelTimerObjectCreated");

        if (obj != null || lastSceneIndexInfo != nowSceneIndexInfo)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = "LevelTimerObjectCreated";
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        nowSceneIndexInfo = sceneIndex;

        if (sceneIndex != lastSceneIndexInfo)
        {
            Destroy(this.gameObject);
        }

        LevelTimerFunc();
    }

    

    private void LevelTimerFunc()
    {
        time += Time.deltaTime;

        scoreMultiplier = 100 / time + 1; //need to make it better
        PlayerPrefs.SetFloat("levelScoreMultiplier", scoreMultiplier);
    }
}
