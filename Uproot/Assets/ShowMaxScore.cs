using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMaxScore : MonoBehaviour
{
    private float maxScore;
    private Text maxScoreTextComponent;
    public int levelNumber;

    private void Awake()
    {
        maxScoreTextComponent = GetComponent<Text>();

        maxScore = PlayerPrefs.GetFloat($"maxScoreLevel{levelNumber}", maxScore);
        maxScoreTextComponent.text = $"Max Score: {maxScore}";
    }
}
