using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    public string[] PlayerPrefsMaxScores = new string[9];
    public int currentLevel;

    public void CheckPlayerPrefsMaxScores(string[] PlayerPrefsScores)
    {
        Debug.Log("CheckPlayerPrefs script is on...");

        for (int i = 0; i < PlayerPrefsScores.Length; i++)
        {
            PlayerPrefsScores[i] = PlayerPrefs.GetFloat($"maxScoreLevel{i + 1}").ToString();
        }
    }
    public void ChangePlayerPrefsMaxScores(string[] PlayerPrefsScores)
    {
        Debug.Log("ChangePlayerPrefs script is on...");

        for (int i = 0; i < PlayerPrefsScores.Length; i++)
        {
            PlayerPrefs.SetFloat($"maxScoreLevel{i + 1}", 0);
            PlayerPrefsScores[i] = PlayerPrefs.GetFloat($"maxScoreLevel{i + 1}").ToString();
        }
    }

    public void ChangePlayerPrefsCurrentLevel()
    {
        PlayerPrefs.SetInt("currentScene", 1);
        currentLevel = PlayerPrefs.GetInt("currentScene");
        Debug.Log($"currentLevel = {currentLevel}");
    }

    public void CheckPlayerPrefsCurrentLevel()
    {
        currentLevel = PlayerPrefs.GetInt("currentScene");
    }

    public void ClickToReset()
    {
        
        ChangePlayerPrefsMaxScores(PlayerPrefsMaxScores);
        ChangePlayerPrefsCurrentLevel();
    }

    public void ClickToCheck()
    {
        CheckPlayerPrefsMaxScores(PlayerPrefsMaxScores);
        CheckPlayerPrefsCurrentLevel();
    }
}
