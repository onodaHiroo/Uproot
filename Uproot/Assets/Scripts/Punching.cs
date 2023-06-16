using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Punching : MonoBehaviour
{
    public float punchStunTime = 10;
    public bool withWeaponOn = false;
    public string enemyTag;
    public Enemy enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        withWeaponOn = TakeAndDropWeapon.withWeapon; //i think this is not too optimizated but it makes punching work correctly
        if (Input.GetMouseButtonDown(0) && enemyTag == "Enemy" && withWeaponOn == false) 
        {
            enemy.GetPunched(punchStunTime);
            Debug.Log("You punched the enemy!");
        }
    }

    public void CollisionDetected(Collider2D collider)
    {
        enemyTag = collider.tag;
        enemy = collider.transform.GetComponent<Enemy>();
    }
}
