using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMaxScore : MonoBehaviour
{
    private int maxScore;
    private Text maxScoreTextComponent;
    public int levelNumber;

    private void Awake()
    {
        maxScoreTextComponent = GetComponent<Text>();

        maxScore = PlayerPrefs.GetInt($"maxScoreLevel{levelNumber}", maxScore);
        maxScoreTextComponent.text = $"Max Score: {maxScore}";
    }
}
