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

    public void Start()
    {
        score = PlayerPrefs.GetInt("playerScoreLevel1", score);
        maxScore = PlayerPrefs.GetInt("maxScoreLevel1", maxScore);

        scoreTextComponent.text = $"Score: {score}";
        maxScoreTextComponent.text = $"Max Score: {maxScore}";
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowScore()
    {
        
    }
}
