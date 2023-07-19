using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ExitFromLevel : MonoBehaviour
{
    public bool canExit = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();

        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    private void Update()
    {
        canExit = FindObjectOfType<LevelManager>().AllEnemiesAreDead(); //maybe not optimized but let it be

        if (canExit)
        {
            int thisLevelBuildIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.GetInt($"playerScoreLevel{thisLevelBuildIndex - 1}", FindObjectOfType<CountDownTheScore>().score);

            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canExit)
        {
            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(1); //there need to be score table
            }
        }
    }
}
