using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFindMusicObject : MonoBehaviour
{
    [SerializeField] private GameObject referenceToMusicObject;

    private void Update()
    {
        if (referenceToMusicObject == null)
        {
            referenceToMusicObject = FindObjectOfType<MusicManager>().gameObject;

            this.gameObject.GetComponent<Toggle>().onValueChanged.AddListener((delegate
            {
                referenceToMusicObject.GetComponent<MusicManager>().ToggleMusic();
            }));
        }
    }
}
