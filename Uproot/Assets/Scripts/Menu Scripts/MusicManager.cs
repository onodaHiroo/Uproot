using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Toggle toggleMusic;
    public Slider sliderVolumeMusic;
    public AudioSource audio;
    public float volume;
    public GameObject SettingsWindow;



    // Start is called before the first frame update
    void Awake()
    {
        Load();
        ValueMusic();
    }

    private void Update()
    {
        SettingsWindow = GameObject.FindGameObjectWithTag("PauseSettingsWindow");

        if (SettingsWindow != null)
        {
            toggleMusic = GameObject.FindGameObjectWithTag("Music Toggle").GetComponent<Toggle>();
            sliderVolumeMusic = GameObject.FindGameObjectWithTag("Music Slider").GetComponent<Slider>();
        }
    }

    public void SliderMusic()
    {
        volume = sliderVolumeMusic.value;
        Save();
        ValueMusic();
    }

    public void ToggleMusic()
    {
        if (toggleMusic.isOn)
        {
            volume = 1;
        }
        else
        {
            volume = 0;
        }
        Save();
        ValueMusic();
    }

    private void ValueMusic()
    {
        audio.volume = volume;
        if (sliderVolumeMusic != null && toggleMusic != null)
        {
            sliderVolumeMusic.value = volume;
            if (volume == 0) { toggleMusic.isOn = false; } else { toggleMusic.isOn = true; }
        }
        
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volume);
    }
    private void Load()
    {
        volume = PlayerPrefs.GetFloat("volume", volume);
    }
}
