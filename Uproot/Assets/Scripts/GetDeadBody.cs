using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDeadBody : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>()
            .sprite = FindObjectOfType<DeadBodyManager>().GetDeadBodySprite(gameObject);
    }
    private void OnMouseEnter()
    {
        if (gameObject.tag == "Enemy")
            FindObjectOfType<CursorScript>()
                .ToEnemyExit();
    }

    private void OnMouseExit()
    {
        if (gameObject.tag == "Enemy")
            FindObjectOfType<CursorScript>()
                .ToEnemyExit();
    }

}
