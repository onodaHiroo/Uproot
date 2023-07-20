using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCheckMenuScript : MonoBehaviour
{
    [Header("Refs")]
    public Text scoreTextComponent;
    public Text maxScoreTextComponent;
    public Text levelScoreMultiplierTextComponent;
    public Text finalScoreTextComponent;

    [Header("Check values")]
    public float score;
    public float maxScore;
    public float levelScoreMultiplier;
    public float finalScore;

    [Header("Check level index")]
    public int checkCurrentLevelIndex;

    public void Start()
    {
        checkCurrentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", checkCurrentLevelIndex);

        score = PlayerPrefs.GetFloat($"playerScoreLevel{checkCurrentLevelIndex - 1}", score);
        maxScore = PlayerPrefs.GetFloat($"maxScoreLevel{checkCurrentLevelIndex - 1}", maxScore);
        levelScoreMultiplier = PlayerPrefs.GetFloat("levelScoreMultiplier", levelScoreMultiplier);
        
        finalScore = score * levelScoreMultiplier;
        if (finalScore > maxScore)
        {
            maxScore = finalScore;
        }
        PlayerPrefs.SetFloat($"playerScoreLevel{checkCurrentLevelIndex - 1}", finalScore);
        PlayerPrefs.SetFloat($"maxScoreLevel{checkCurrentLevelIndex - 1}", maxScore);


        scoreTextComponent.text = $"Score: {score}";
        maxScoreTextComponent.text = $"Max Score: {maxScore}";
        levelScoreMultiplierTextComponent.text = $"Speed Multiplier: {levelScoreMultiplier}";
        finalScoreTextComponent.text = $"Final Score: {finalScore}";

    }

    public void GoToMenu()
    {
        PlayerPrefs.SetInt("currentLevelIndex", 0);
        PlayerPrefs.SetFloat("levelScoreMultiplier", 0f);
        SceneManager.LoadScene(0);
    }
}
