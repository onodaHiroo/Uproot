using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOfPicking : MonoBehaviour
{
    private AudioSource audioSource;
    private string checkTag;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        checkTag = transform.parent.parent.parent.tag;
        if (checkTag == "Player")
        {
            audioSource.Play();
        }
    }
}
