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
}
