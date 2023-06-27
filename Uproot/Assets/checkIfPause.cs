using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfPause : MonoBehaviour
{
    private PlayerMovement pm;
    private TakeAndDropWeapon tadw;
    private Punching punching;
    private WalkingAnimation anim;
    private CameraRotateEffect cameraRotation;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        tadw = GetComponent<TakeAndDropWeapon>();
        punching = GetComponent<Punching>();
        anim = GetComponentInChildren<WalkingAnimation>();
        cameraRotation = GetComponent<CameraRotateEffect>();
    }


    
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            pm.enabled = false;
            tadw.enabled = false;
            punching.enabled = false;
            anim.enabled = false;
            cameraRotation.enabled = false;
        }
        else
        {
            pm.enabled = true;
            tadw.enabled = true;
            punching.enabled = true;
            anim.enabled = true;
            cameraRotation.enabled = true;
        }
    }
}
