using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CountDownTheScore : MonoBehaviour
{
    public float score;
    public float maxScore;
    public Text scoreText;
    public int levelIndex;

    public void Awake()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;


        GetMaxScore(levelIndex);
        PlayerPrefs.SetInt("currentLevelIndex", levelIndex);

    }

    public void Update()
    {
        scoreText.text = $"Score: {score}";

        

        if (maxScore < score)
        {
            maxScore = score;
            SetMaxScore(levelIndex);
        }
    }

    public void SetMaxScore(int levelIndex)
    {
        PlayerPrefs.SetFloat($"maxScoreLevel{levelIndex - 1}", maxScore);
    }
    public void GetMaxScore(int levelIndex)
    {
        maxScore = PlayerPrefs.GetFloat($"maxScoreLevel{levelIndex - 1}", maxScore);
    }

}
