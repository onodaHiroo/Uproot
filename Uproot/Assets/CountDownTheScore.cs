using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CountDownTheScore : MonoBehaviour
{
    public int score;
    public int maxScore;
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
        PlayerPrefs.SetInt($"maxScoreLevel{levelIndex - 1}", maxScore);
    }
    public void GetMaxScore(int levelIndex)
    {
        maxScore = PlayerPrefs.GetInt($"maxScoreLevel{levelIndex - 1}", maxScore);
    }

}
