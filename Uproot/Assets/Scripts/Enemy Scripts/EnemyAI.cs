using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyType
    {
        patrol,
        pursingPlayer,
        goingToLastLoc
    }
    public EnemyType enemyType;

    GameObject player;

    public bool clockwise, moving, guard;

    Vector3 target;
    Rigidbody2D rb;
    public Vector3 playerLastPos;
    RaycastHit2D hit;

    public float speed;

    int layermask = 3 << 8;

    public Transform check;

    public bool shooting;

    public string checkCollider;

    public Transform weaponHoldPoint;
    public GameObject weaponPrefab;

    public GameObject weapon;//serialized nado sdelat

    [SerializeField]
    private float _period = 0.1f;

    public float _timerFire;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        playerLastPos = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        layermask = ~layermask;

        weapon = Instantiate(weaponPrefab, weaponHoldPoint.transform.position, weaponHoldPoint.rotation);
        weapon.transform.parent = weaponHoldPoint.transform;

    }


    void FixedUpdate()
    {
        if (player != null)
        {
            Movement();
            PlayerDetect();
            _timerFire += Time.deltaTime;
        }
    }

    void Movement()
    {
        float dist = Vector3.Distance (player.transform.position, this.transform.position);
        Vector3 dir = player.transform.position - transform.position; 
        hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dir.x, dir.y), dist, layermask);
        Debug.DrawRay(transform.position, dir, Color.red); 

        Vector3 fwt = this.transform.TransformDirection(Vector3.up);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2 (fwt.x, fwt.y), 2.0f, layermask);
        Debug.DrawRay(transform.position, fwt, Color.cyan);
        
        if (player != null)
        {
            checkCollider = hit.collider.gameObject.name; //из-за убийства игрока вылетают ошибки, надо поправить
        }

        if (moving)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (enemyType == EnemyType.patrol)
        {

            speed = 3.0f;
            
            if (hit2.collider != null)
            {
                if (hit2.collider.gameObject.layer == 11)
                {
                    if (!clockwise)
                    {
                        transform.Rotate(0, 0, 90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
            }
        }

        if (enemyType == EnemyType.pursingPlayer)
        {
            speed = 15f;
            rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((playerLastPos.y - transform.position.y), (playerLastPos.x - transform.position.x)) * Mathf.Rad2Deg - 90);
            


            if (hit.transform.gameObject.layer == 10)
            {
                playerLastPos = player.transform.position;

                Shooting();

                if (Vector3.Distance (transform.position, player.transform.position) <= 12f /*&& hit.collider.gameObject.tag == "Player"*/)
                {
                    moving = false;

                    //Shooting(); //короче я хз тут чето не так
                    
                }
                else
                {
                    if (!guard)
                    {
                        moving = true;
                    }
                }
            }  
        }
        
        if (enemyType == EnemyType.goingToLastLoc)
        {
            if (!guard)
            {
                moving = true;
                speed = 15f;

                rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((playerLastPos.y - transform.position.y), (playerLastPos.x - transform.position.x)) * Mathf.Rad2Deg - 90);

                if (Vector3.Distance(this.transform.position, playerLastPos) < 1.5f)
                {
                    enemyType = EnemyType.patrol;
                    
                }
            }
            else
            {
                rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((playerLastPos.y - transform.position.y), (playerLastPos.x - transform.position.x)) * Mathf.Rad2Deg - 90);
            }
        }
    }

    void PlayerDetect()
    {
        Vector3 pos = this.transform.InverseTransformPoint(player.transform.position);

        if (hit.collider != null)
        {
            if (hit.transform.gameObject.layer == 10 && /*pos.y > 1.0f &&*/ Vector3.Distance(this.transform.position, player.transform.position) < 50.0f)
            {
                enemyType = EnemyType.pursingPlayer;
            }
            else
            {
                if (enemyType == EnemyType.pursingPlayer)
                {
                    enemyType = EnemyType.goingToLastLoc;
                }
            }
        }
    }

    void Shooting()
    {
        if (_timerFire >= _period)
        {
            weapon.GetComponentInChildren<EnemyShooting>().EnemyShoot();
        }
    }
}
