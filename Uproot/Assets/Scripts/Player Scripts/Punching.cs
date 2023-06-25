using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Punching : MonoBehaviour
{
    public float punchStunTime = 10;
    public static bool withWeaponOn = false;
    public string objectTagInFrontOfPlayer;
    public Enemy enemy;

    public AudioSource punchSound;
    public AudioSource sweepSound;

    private Animator punchAnimator;


    void Start()
    {
        punchAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && withWeaponOn == false)
        {
            punchAnimator.SetBool("Punched",true);
            if (objectTagInFrontOfPlayer == "Enemy")
            {
                enemy.GetPunched(punchStunTime);
                punchSound.Play();
                Debug.Log("You punched the enemy!");
            }
            else
            {
                sweepSound.Play();
            }
        }
    }

    public void CollisionDetected(Collider2D collider)
    {
        objectTagInFrontOfPlayer = collider.tag;
        enemy = collider.transform.GetComponent<Enemy>();
    }

    private void OnTheEndOfAnimation()
    {
        punchAnimator.SetBool("Punched", false);
    }
}
