using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BacgroundControllerInstanceComponent : MonoBehaviour
{
    [Header("Check between scenes")]
    [SerializeField] private int nowSceneIndexInfo;
    [SerializeField] private int lastSceneIndexInfo;

    [Header("Check references")]
    [SerializeField] private Slider referenceToSliderComponent;
    //[SerializeField] private Toggle referenceToTogleComponent;


    void Awake()
    {
        lastSceneIndexInfo = SceneManager.GetActiveScene().buildIndex;
        nowSceneIndexInfo = SceneManager.GetActiveScene().buildIndex;

        GameObject obj = GameObject.FindWithTag("MusicObjectCreated");

        if (obj != null || lastSceneIndexInfo != nowSceneIndexInfo)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = "MusicObjectCreated";
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        nowSceneIndexInfo = sceneIndex;

        if (sceneIndex != lastSceneIndexInfo)
        {
            Destroy(this.gameObject);
        }
    }
}
