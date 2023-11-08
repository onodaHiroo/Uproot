using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float Health = 100;

    public Sprite sprite; // Drag your first sprite here
    public Sprite deadBodySprite; // Drag your second sprite here
    private SpriteRenderer spriteRenderer;

    public GameObject deadBody;
    public GameObject deadBodyBloodAnim;
    public StunTimerScript stunTimer;

    public float _timeInStun;
    public float _timerStartPunched;

    public bool stunned;

    public GameObject weapon;
    private GameObject weaponUnder;
    public bool ifStunTimerIsOver = false;

    public GameObject stunnedEnemyGameObject;
    public GameObject unStunAnimGameObject;

    public GameObject floatingScore;

    [HideInInspector] public Quaternion rotationToSpawnBloodSplash;

    private void Awake()
    {
        weapon = GetComponent<EnemyAI>().weaponPrefab;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite; // set the sprite to sprite1
        
    }

    // Update is called once per frame
    void Update()
    {
        //after the stun
        if (ifStunTimerIsOver == true)
        {
            stunned = false;
            Debug.Log("stun time is over");
            //Destroy(weaponUnder.gameObject);

            if (weapon != null)
            {
                //Destroy(GetComponentInChildren<EnemyShooting>().gameObject);
            }
            ifStunTimerIsOver = false;
        }
    }

    private void FixedUpdate()
    {
        //if (EnemyDead() == true)
        //{
        //    ShakeCamera();
        //}
    }

    private void EnemyDead()
    {
        SpawnScore();
        InstantiateBloodSplash(rotationToSpawnBloodSplash);
        Destroy(gameObject);


        //Shaking camera
        ShakeCamera();
        //Shaking camera

        Quaternion rotationToSpawnDeadBody = new Quaternion(0,0,180,0) * rotationToSpawnBloodSplash; 
        GameObject enemyDead = Instantiate(deadBody, transform.position, rotationToSpawnDeadBody);
        GameObject flowingBlood = Instantiate(deadBodyBloodAnim, transform.position, rotationToSpawnDeadBody);
        Debug.Log($"{gameObject} is dead");

        if (FindObjectOfType<CountDownTheScore>() != null)
            FindObjectOfType<CountDownTheScore>().gameObject.GetComponent<CountDownTheScore>().score += 500f;
        
        if (weapon != null )
        {
            if (GetComponentInChildren<EnemyShooting>() != null)
                Destroy(GetComponentInChildren<EnemyShooting>().gameObject);

            GameObject spawnedWeapon = Resources.Load<GameObject>($"Prefabs/Guns/Common/{weapon.name.Replace("holding_", "").Replace("(Clone)", "")}");
            GameObject lyingWeapon = Instantiate(spawnedWeapon, transform.position, Quaternion.identity);
            lyingWeapon.name = $"{lyingWeapon.name.Replace("(Clone)", "")}"; //to give them their full ammo
        }

        FindObjectOfType<CursorScript>().ToEnemyExit();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{gameObject} took {damage} damage");
        Health -= damage;

        if (Health <= 0)
        {
            Health = 0;
            EnemyDead();
        }
    }

    public void GetPunched(float time)
    {
        gameObject.SetActive(false);
        GameObject stunnedEnemy = Instantiate(stunnedEnemyGameObject, transform.position, transform.rotation);
        stunned = true;

        StunTimerScript timer = Instantiate(stunTimer, transform.position, transform.rotation);
        timer.stunTime = time;
        timer.enemy = this;
        timer.enemyStunned = stunnedEnemy;
        timer.enemyUnStunAnim = unStunAnimGameObject;
        
        if (weapon != null )
        {
            Destroy(GetComponentInChildren<EnemyShooting>().gameObject);

            GameObject spawnedWeapon = Resources.Load<GameObject>($"Prefabs/Guns/Common/{weapon.name.Replace("holding_", "").Replace("(Clone)", "")}");
            GameObject lyingWeapon = Instantiate(spawnedWeapon, transform.position, Quaternion.identity);
            lyingWeapon.name = $"{lyingWeapon.name.Replace("(Clone)", "")}"; //to give them their full ammo
        }

        //weaponUnder = lyingWeapon;

        gameObject.GetComponent<Enemy>().weapon = null;
        gameObject.GetComponent<EnemyAI>().weapon = null;
        gameObject.GetComponent<EnemyAI>().weaponPrefab = null;
        gameObject.GetComponent<EnemyAI>().canShoot = false;

        gameObject.GetComponent<EnemyAI>().guard = true;
        
        //gameObject.GetComponent<EnemyAI>().moving = false;

        

        GetComponent<EnemyAI>().moving = false;
        gameObject.GetComponent<EnemyAI>().enemyType = EnemyAI.EnemyType.patrol;

        FindObjectOfType<CursorScript>().ToEnemyExit();
    }
    public void SpawnScore()
    {
        int cord = UnityEngine.Random.Range(-5, 5);
        Vector2 floatingScorePos = new Vector2(transform.position.x + cord, transform.position.y + cord);
        Instantiate(floatingScore, floatingScorePos, Quaternion.identity);
    }

    private void OnMouseOver()
    {
        CursorScript gm = GameObject.FindObjectOfType<CursorScript>();
        gm.ToEnemyEnter();
    }

    private void OnMouseExit()
    {
        CursorScript gm = GameObject.FindObjectOfType<CursorScript>();
        gm.ToEnemyExit();
    }

    private void InstantiateBloodSplash(Quaternion rotationToSpawnBloodSplash)
    {   
        int rand = Random.Range(-1, 1);
        //туповато но пока сойдет
        if (rand == 0) rand = 1;

        GameObject splash = FindObjectOfType<DeadBodyManager>().GetBloodSplashGameObject();
        splash.transform.localScale = new Vector3(splash.transform.localScale.x * rand, splash.transform.localScale.y, splash.transform.localScale.z);
        Instantiate(splash, transform.position, rotationToSpawnBloodSplash);
        
    }

    private void ShakeCamera()
    {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.GetComponent<CameraShakeEffect>().StartShaking(2, new Vector2(0.5f, 0.5f));
    }
}
