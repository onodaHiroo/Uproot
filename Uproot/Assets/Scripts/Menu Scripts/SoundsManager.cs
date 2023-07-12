using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;
    public Toggle toggleVolumeSounds;
    public GameObject SettingsWindow;

    [Header("Saved  Values")]
    [SerializeField] private float volumeValueSave;
    [SerializeField] private float valueSave;


    private const float _multiplier = 20f;

    private void Start()
    {
        Load();
    }

    private void Awake()
    {
        Load();
        slider.value = valueSave;
        slider.onValueChanged.AddListener(HandleSliderValueChanged);

    }

    private void Update()
    {
        SettingsWindow = GameObject.FindGameObjectWithTag("PauseSettingsWindow");
        if (SettingsWindow != null)
        {
            if (toggleVolumeSounds == null)
                toggleVolumeSounds = GameObject.FindWithTag("Sounds Toggle").GetComponent<Toggle>();
        }
    }

    public void ToggleSounds()
    {
        if (toggleVolumeSounds.isOn == true)
        {
            volumeValueSave = 0;
            valueSave = 1;
            //Load();
            slider.value = valueSave;
            //Save();
        }
        else if (toggleVolumeSounds.isOn == false)
        {

            volumeValueSave = -80;
            valueSave = 0;
            //Load();
            slider.value = valueSave;
            //Save();
        }
        Save();
    }

    private void HandleSliderValueChanged(float value)
    {
        valueSave = value;
        if (value != 0)
        {
            //toggleSounds.isOn.Equals(true);
            //toggleSounds.isOn = true; //there is a problem in main menu

            if (toggleVolumeSounds.isOn == false)
            {
                toggleVolumeSounds.isOn = true;
            }
            
            var volumeValue = Mathf.Log10(value) * _multiplier;
            volumeValueSave = volumeValue;
            mixer.SetFloat(volumeParameter, volumeValue);
            Save();
        }
        else
        {
            //toggleSounds.isOn.Equals(false);
            if (toggleVolumeSounds.isOn == true)
            {
                toggleVolumeSounds.isOn = false;
            }
            
            var volumeValue = -80;
            volumeValueSave = volumeValue;
            mixer.SetFloat(volumeParameter, volumeValue);
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("SFXVol", volumeValueSave);
        //mixer.SetFloat("SFXVol", volumeValue1);
        PlayerPrefs.SetFloat("valueSave", valueSave);
    }
    private void Load()
    {
        volumeValueSave = PlayerPrefs.GetFloat("SFXVol", volumeValueSave);
        mixer.SetFloat("SFXVol", volumeValueSave);
        valueSave = PlayerPrefs.GetFloat("valueSave", valueSave);
    }
}
