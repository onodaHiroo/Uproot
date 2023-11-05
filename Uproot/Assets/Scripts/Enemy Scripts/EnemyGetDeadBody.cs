using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetDeadBody : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>()
            .sprite = FindObjectOfType<SpawnDeadBody>().GetDeadBodySprite(gameObject);
    }
}
