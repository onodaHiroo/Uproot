using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfPlayerToShoot : MonoBehaviour
{
    Shooting shooting;
    EnemyShooting enemyShooting;
    private string checkTag;
    void Start()
    {
        shooting = GetComponent<Shooting>();
        enemyShooting = GetComponent<EnemyShooting>();

        checkTag = transform.parent.parent.parent.tag;
        if (checkTag != "Player")
        {
            shooting.enabled = false;
            enemyShooting.enabled = true;
        }
        else 
        {
            shooting.enabled = true;
            enemyShooting.enabled = false;
        }
    }
}
