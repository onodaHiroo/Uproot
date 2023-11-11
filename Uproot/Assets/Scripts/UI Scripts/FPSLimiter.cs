using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FPSLimiter : MonoBehaviour
{
    [Header ("Changed Properties. Press 'F' button to apply")]
    [SerializeField] private int targetFPS;
    [SerializeField] private int targetVSyncCount;

    [Header ("Start Properties")]
    [SerializeField] private int maxFPS = -1;
    [SerializeField] private int StartVSyncCount = 1;

    [Header("Checks")]
    [SerializeField] private bool fpsChanged = false;


    public static FPSLimiter instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        maxFPS = -1;
        StartVSyncCount = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !fpsChanged)
        {
            targetFPS = 40;
            Application.targetFrameRate = targetFPS;
            QualitySettings.vSyncCount = 0;
            targetVSyncCount = QualitySettings.vSyncCount;
            
            if (Application.targetFrameRate != targetFPS)
                Application.targetFrameRate = targetFPS;
            fpsChanged = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && fpsChanged)
        {
            targetFPS = maxFPS;
            Application.targetFrameRate = targetFPS;
            QualitySettings.vSyncCount = StartVSyncCount;
            targetVSyncCount = QualitySettings.vSyncCount;
            

            if (Application.targetFrameRate != targetFPS)
                Application.targetFrameRate = targetFPS;
            fpsChanged = false;
        }
        
    }

}
