using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Punching : MonoBehaviour
{
    public float punchStunTime = 10;
    public static bool withWeaponOn = false;
    public string enemyTag;
    public Enemy enemy;
    public AudioSource punchSound;

    public Animator punchAnimator;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && withWeaponOn == false)
        {
            punchAnimator.SetBool("Punched",true);
            if (enemyTag == "Enemy")
            {
                enemy.GetPunched(punchStunTime);
                PunchSound();
                Debug.Log("You punched the enemy!");
            }
        }
    }

    public void CollisionDetected(Collider2D collider)
    {
        enemyTag = collider.tag;
        enemy = collider.transform.GetComponent<Enemy>();
    }

    private void PunchSound()
    {
        punchSound.Play();
    }

    private void OnTheEndOfAnimation()
    {
        punchAnimator.SetBool("Punched", false);
    }
}
