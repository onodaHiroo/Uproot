using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ArrowLookToExit : MonoBehaviour
{
    public GameObject exit;
    private float rotation;
    private float startLocalScaleY;

    private void Start()
    {
        startLocalScaleY = gameObject.transform.localScale.y;
    }
    // Update is called once per frame
    void Update()
    {
        CheckWhereIsTheExit();
        RotateToExit();
    }

    public void CheckWhereIsTheExit()
    {
        float dist = Vector3.Distance(exit.transform.position, this.transform.position);
        Vector3 dir = exit.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dir.x, dir.y), dist);
        Debug.DrawRay(transform.position, dir, Color.blue);
    }
    public void RotateToExit()
    {
        rotation = Mathf.Atan2((exit.transform.position.y - transform.position.y), (exit.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 180;
        gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((exit.transform.position.y - transform.position.y), (exit.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 180);

        if ((rotation > -270) && (rotation <= -90))
        {
            if (gameObject.transform.localScale.y > 0)
            {
                gameObject.transform.localScale = new Vector3(
                    gameObject.transform.localScale.x, 
                    startLocalScaleY * -1, 
                    gameObject.transform.localScale.z);
            }
        }
        if(!((rotation > -270) && (rotation <= -90)))
        {
            if (gameObject.transform.localScale.y < 0)
            {
                gameObject.transform.localScale = new Vector3
                    (gameObject.transform.localScale.x, 
                    startLocalScaleY, 
                    gameObject.transform.localScale.z);

            }
        }
    }
}
