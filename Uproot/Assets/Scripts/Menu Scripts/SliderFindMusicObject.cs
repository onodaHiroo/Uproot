using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFindMusicObject : MonoBehaviour
{
    [SerializeField] private GameObject referenceToMusicObject;

    private void Update()
    {
        if (referenceToMusicObject == null)
        {
            referenceToMusicObject = FindObjectOfType<MusicManager>().gameObject;

            this.gameObject.GetComponent<Slider>().onValueChanged.AddListener((delegate
            {
                referenceToMusicObject.GetComponent<MusicManager>().SliderMusic();
            }));
        }
    }
}
