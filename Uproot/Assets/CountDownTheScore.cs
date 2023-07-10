using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CountDownTheScore : MonoBehaviour
{
    public int score;

    public Text scoreText;

    public void Update()
    {
        scoreText.text = $"Score: {score}";
    }
}
