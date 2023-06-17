using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TakeAndDropWeapon : MonoBehaviour
{
    public GameObject currentWeapon = null;
    public GameObject whichWeaponWeOn = null;
    private GameObject _onlyBody;

    public Transform holdPoint;

    private SpriteRenderer spriteRenderer;

    public Sprite holdingGun;
    public Sprite notHoldingGun;

    public static bool withWeapon = false;




    void Start()
    {
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        _onlyBody = GameObject.Find("OnlyBody");
        _onlyBody.SetActive(false);
        ChangePlayerSprite();   
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            WeaponManager();
            AmmoTextUi.checkIfWithWeapon = withWeapon;
            Punching.withWeaponOn = withWeapon;
        }   
    }

    private void WeaponManager()
    {
        if (whichWeaponWeOn != null && currentWeapon == null)
        {
            PickWeapon(whichWeaponWeOn);
            withWeapon = true;
            ChangePlayerSprite();
        }
        else if (whichWeaponWeOn == null && currentWeapon != null)
        {
            DropWeapon(currentWeapon);
            withWeapon = false;
            ChangePlayerSprite();
        }
        else if (whichWeaponWeOn != null && currentWeapon != null)
        {
            ChangeWeapon(currentWeapon, whichWeaponWeOn);
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.transform.tag == "Weapon")
        {
            whichWeaponWeOn = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Weapon")
        {
            whichWeaponWeOn = null;
        }
    }

    private void PickWeapon(GameObject weapon)
    {
        SpawnHoldingWeapon();
        Debug.Log($"Weapon {weapon} is picked");
        Destroy(whichWeaponWeOn);

        Shooting.bulletAmmo = weapon.GetComponent<AmmoIn>().ammoInsideGun;

        AmmoTextUi.sizeClip = weapon.GetComponent<AmmoIn>().sizeOfClip;
    }

    private void DropWeapon(GameObject weapon)
    {
        SpawnLyingWeapon();
        Debug.Log($"Weapon {weapon} is dropped");
        Destroy(currentWeapon);
        currentWeapon = null;

        Shooting.bulletAmmo = 0;
        AmmoTextUi.ammoBullets = 0;
        AmmoTextUi.sizeClip = 0;
    }

    private void ChangeWeapon(GameObject CurrentWeapon, GameObject WhichWeaponWeOn)
    {
        //i dont even give a fuck how it works

        GameObject tempCurrentWeapon = CurrentWeapon;
        SpawnLyingWeapon();

        Destroy(CurrentWeapon);
        SpawnHoldingWeapon();
        Debug.Log($"Weapon {tempCurrentWeapon} is dropped");

        Destroy(WhichWeaponWeOn);
        whichWeaponWeOn = tempCurrentWeapon;

        Debug.Log($"Weapon {WhichWeaponWeOn} is picked");
        withWeapon = true;
        Shooting.bulletAmmo = WhichWeaponWeOn.GetComponent<AmmoIn>().ammoInsideGun;
        AmmoTextUi.sizeClip = WhichWeaponWeOn.GetComponent<AmmoIn>().sizeOfClip;


    }

    public void SpawnHoldingWeapon()
    {
        GameObject tempcurrentWeapon = Resources.Load<GameObject>($"Prefabs/Guns/Holding/holding_{whichWeaponWeOn.name.Replace("(Clone)", "")}");
        GameObject weapon = Instantiate(tempcurrentWeapon, holdPoint.transform.position, holdPoint.rotation);
        weapon.transform.parent = holdPoint.transform;
        currentWeapon = weapon;
    }

    private void SpawnLyingWeapon()
    {
        GameObject whichWeaponWeOn = Resources.Load<GameObject>($"Prefabs/Guns/Common/{currentWeapon.name.Replace("holding_", "").Replace("(Clone)", "")}");
        GameObject weapon = Instantiate(whichWeaponWeOn, transform.position, Quaternion.identity);

        weapon.GetComponent<AmmoIn>().ammoInsideGun = Shooting.bulletAmmo;
        weapon.GetComponent<AmmoIn>().sizeOfClip = AmmoTextUi.sizeClip;
    }

    private void ChangePlayerSprite() //установка положения держащего в руках гг
    {
        if (withWeapon)
        {
            Animator animator = GetComponent<Animator>();
            animator.enabled = false;
            spriteRenderer.sprite = holdingGun;
            _onlyBody.SetActive(true);
        }
        else
        {
            Animator animator = GetComponent<Animator>();
            animator.enabled = true;
            spriteRenderer.sprite = notHoldingGun;
            _onlyBody.SetActive(false);

        }
    }


    
}
