using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraRotateEffect : MonoBehaviour
{
    PlayerMovement pm;
    float mod = 0.002f;
    float zVal = 0.0f;

    private void Start()
    { 
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Debug.Log($"������� ������� �������� � :({Thread.CurrentThread}) ������");
    }

    private void Update()
    {
        if (pm.isMoving == true)
        {
            Vector3 rot = new Vector3 (0, 0, zVal);
            this.transform.eulerAngles = rot;

            zVal += mod;

            if (transform.eulerAngles.z >= 2.0f && transform.eulerAngles.z < 7.0f) //����� �������� �������� ������ ���
            {
                //mod = -0.002f; //� ���
                mod = -Time.deltaTime;
            }
            else if (transform.eulerAngles.z < 358.0f && transform.eulerAngles.z > 353.0f) //� ���
            {
                //mod = 0.002f; //� ���
                mod = Time.deltaTime;
            }
            
        }
    }
}
