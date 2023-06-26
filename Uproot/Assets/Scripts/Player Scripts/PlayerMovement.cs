using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigidBody2D;
    private Vector2 movement;

    public Camera cam;
    Vector2 mousePos;

    public Animator runningAnimator;


    private void Start()
    {
        runningAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        ChangeCamPos(true);
    }

    void FixedUpdate()
    {
        rigidBody2D.MovePosition(rigidBody2D.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rigidBody2D.position;
        float rotateAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidBody2D.rotation = rotateAngle;        
    }

    public void ChangeCamPos(bool val)
    {
        if (val)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }



}
