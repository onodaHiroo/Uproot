using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene(0); //there need to be score table
            }
        }
    }
}
