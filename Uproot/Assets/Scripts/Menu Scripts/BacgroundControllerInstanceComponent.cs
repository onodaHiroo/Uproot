using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BacgroundControllerInstanceComponent : MonoBehaviour
{
    [SerializeField] private int nowSceneIndexInfo;
    [SerializeField] private int lastSceneIndexInfo;
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

        //gameObject.GetComponent<MusicManager>().toggleMusic = GameObject.FindGameObjectWithTag("Music Toggle").GetComponent<Toggle>();

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
