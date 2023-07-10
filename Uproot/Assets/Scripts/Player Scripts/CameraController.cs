using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTransform;
    GameObject player;
    PlayerMovement pm;
    public bool followPlayer = true;
    Vector3 mousePos;
    Camera cam;

    [Header("Limits")]
    [SerializeField] private float checkDist;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(followTransform.position.x, followTransform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.LeftShift) && player != null)
        {
            followPlayer = false;
            pm.ChangeCamPos(false);
        }
        else
        {
            followPlayer = true;
        }

        if (followPlayer == true)
        {
            CanFollowPlayer();
            
        }
        else
        {
            LookAhead();
        }
    }

    public void SetFollowPlayer(bool val)
    {
        followPlayer = val;
    }

    void CanFollowPlayer()
    {
        if (player != null)
        {
            Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            this.transform.position = newPos;
        }   
    }

    private void LookAhead()
    {
        Vector3 camPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        camPos.z = -10;
        Vector3 dir = camPos - this.transform.position;

        checkDist = Vector3.Distance(cam.transform.position, player.transform.position);

        if (player.GetComponent<SpriteRenderer>().isVisible == true /* && checkDist <= 28*/) //при смерит здесь может быть по-другому
        {
            transform.Translate(dir * 2 * Time.deltaTime);
        }
        else
        {
            //КАК!??!?
        }
    }

}
