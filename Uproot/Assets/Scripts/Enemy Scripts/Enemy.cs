using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

    private void EnemyDead()
    {
        Destroy(gameObject);

        //Shaking camera
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.GetComponent<CameraShakeEffect>().StartShaking(5, new Vector2(0.5f, 0.5f));
        //Shaking camera

        GameObject enemyDead = Instantiate(deadBody, transform.position, transform.rotation);
        GameObject flowingBlood = Instantiate(deadBodyBloodAnim, transform.position, transform.rotation);
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
    }

   
}
