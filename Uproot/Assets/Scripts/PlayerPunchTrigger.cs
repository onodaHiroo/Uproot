using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerPunchTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        transform.parent.GetComponent<Punching>().CollisionDetected(collider);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetComponent<Punching>().enemyTag = null;
        transform.parent.GetComponent<Punching>().enemy = null;
    }
}

