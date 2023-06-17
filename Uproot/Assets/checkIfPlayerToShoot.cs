using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfPlayerToShoot : MonoBehaviour
{
    Shooting shooting;
    private string checkTag;
    void Start()
    {
        shooting = GetComponent<Shooting>();
        checkTag = transform.parent.parent.parent.tag;
        if (checkTag != "Player")
        {
            shooting.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
