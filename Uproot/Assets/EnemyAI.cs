using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject weaponHolding;
    public Transform holdPoint;

    public enum EnemyType
    {
        patrol,
        pursingPlayer,
        goingToLastLoc,
    }
    public EnemyType enemyType;

    SpriteRenderer SR;

    GameObject player;
    public bool clockwise, moving, guard;

    Vector3 target;
    Rigidbody2D rb;
    public Vector3 playerLastPos;
    RaycastHit2D hit;

    public float speed;

    int layermask = 1 << 8;

    public Transform check;

    public bool shooting;

    void Start()
    {
        if (weaponHolding != null)
        {
            GameObject weaponOn = Instantiate(weaponHolding, holdPoint.transform.position, holdPoint.rotation);
            weaponOn.transform.parent = holdPoint.transform;
        }
        
    }

    void Update()
    {
        
    }
}
