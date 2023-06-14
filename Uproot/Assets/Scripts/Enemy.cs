using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public float Health = 100;

    public Sprite sprite; // Drag your first sprite here
    public Sprite deadBodySprite; // Drag your second sprite here
    private SpriteRenderer spriteRenderer;

    public GameObject deadBody;
    public GameObject deadBodyBloodAnim;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite; // set the sprite to sprite1
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnemyDead()
    {
        Destroy(gameObject);
        GameObject enemyDead = Instantiate(deadBody, transform.position, transform.rotation);
        GameObject flowingBlood = Instantiate(deadBodyBloodAnim, transform.position, transform.rotation);
        Debug.Log($"{gameObject} is dead");
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{gameObject} took {damage} damage");
        Health -= damage;

        if (Health <= 0)
        {
            Health = 0;
            EnemyDead();
        }
    }
}
