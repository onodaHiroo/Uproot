using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCheckMenuScript : MonoBehaviour
{
    public Text scoreTextComponent;
    public Text maxScoreTextComponent;

    public int score;
    public int maxScore;

    public int checkCurrentLevelIndex;

    public void Start()
    {
        checkCurrentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", checkCurrentLevelIndex);

        score = PlayerPrefs.GetInt($"playerScoreLevel{checkCurrentLevelIndex - 1}", score);
        maxScore = PlayerPrefs.GetInt($"maxScoreLevel{checkCurrentLevelIndex - 1}", maxScore);

        scoreTextComponent.text = $"Score: {score}";
        maxScoreTextComponent.text = $"Max Score: {maxScore}";
    }

    public void GoToMenu()
    {
        PlayerPrefs.SetInt("currentLevelIndex", 0) ;
        SceneManager.LoadScene(0);
    }
}
