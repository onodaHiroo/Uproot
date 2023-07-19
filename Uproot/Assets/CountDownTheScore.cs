using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CountDownTheScore : MonoBehaviour
{
    public int score;
    public int maxScore;
    public Text scoreText;

    public void Awake()
    {
        maxScore = PlayerPrefs.GetInt("maxScoreLevel1", maxScore);
    }

    public void Update()
    {
        scoreText.text = $"Score: {score}";

        if (maxScore < score)
        {
            maxScore = score;
            PlayerPrefs.SetInt("maxScoreLevel1", maxScore);
        }
    }
}
