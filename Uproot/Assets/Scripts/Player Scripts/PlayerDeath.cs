using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public GameObject playerDeathBody;
    public bool isDead = false;
    private GameObject restartText;

    private void Start()
    {
        restartText = GameObject.FindWithTag("RestartText");
    }

    public void Death()
    {
        int maxScoreToSave = gameObject.GetComponent<CountDownTheScore>().maxScore;
        int levelIndex = gameObject.GetComponent<CountDownTheScore>().levelIndex;
        PlayerPrefs.SetInt($"maxScoreLevel{levelIndex - 1}", maxScoreToSave);

        //gameObject.SetActive(false);
        Destroy(gameObject);
        isDead = true;
        Instantiate(playerDeathBody, transform.position, transform.rotation);
        restartText.GetComponent<Text>().enabled = true;
    }

}
