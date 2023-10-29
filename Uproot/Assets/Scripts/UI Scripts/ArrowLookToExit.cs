using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ArrowLookToExit : MonoBehaviour
{
    public GameObject exit;
    [SerializeField] private Vector2 exitTransformPosition;
    [SerializeField] private float rotation;


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
        gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((exit.transform.position.y - transform.position.y), (exit.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 180);
    }
}
