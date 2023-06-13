using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndDropWeapon : MonoBehaviour
{
    public GameObject currentWeapon = null;
    public GameObject whichWeaponWeOn = null;
    public Transform holdPoint;

    private SpriteRenderer spriteRenderer;
    private GameObject _onlyBody;
    public Sprite holdingGun;
    public Sprite notHoldingGun;

    private bool _legsAlreadyChanged;
    protected bool _withWeapon = false;




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
        }
            
    }

    private void WeaponManager()
    {
        if (whichWeaponWeOn != null && currentWeapon == null)
        {
            PickWeapon(whichWeaponWeOn);
            _withWeapon = true;
            ChangePlayerSprite();
        }
        else if (whichWeaponWeOn == null && currentWeapon != null)
        {
            DropWeapon(currentWeapon);
            _withWeapon = false;
            ChangePlayerSprite();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
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
    }

    public void SpawnHoldingWeapon()
    {
        GameObject tempcurrentWeapon = Resources.Load<GameObject>($"Prefabs/Guns/Holding/holding_{whichWeaponWeOn.name.Replace("(Clone)","")}");
        GameObject weapon = Instantiate(tempcurrentWeapon, transform.position, holdPoint.rotation);
        weapon.transform.parent = holdPoint.transform;
        currentWeapon = weapon;
    }

    private void DropWeapon(GameObject weapon)
    {
        SpawnLyingWeapon();
        Debug.Log($"Weapon {weapon} is dropped");
        Destroy(weapon);
        currentWeapon = null;

    }

    private void SpawnLyingWeapon()
    {
        whichWeaponWeOn = Resources.Load<GameObject>($"Prefabs/Guns/Common/{currentWeapon.name.Replace("holding_", "").Replace("(Clone)", "")}");
        Instantiate(whichWeaponWeOn, transform.position, Quaternion.identity);
    }

    private void ChangePlayerSprite() //установка положения держащего в руках гг
    {
        if (_withWeapon)
        {
            spriteRenderer.sprite = holdingGun;
            Transform animationTransform = transform.Find("Animation");
            animationTransform.transform.position = transform.position + new Vector3(0, -0.8f, 0);
            _legsAlreadyChanged = true;
            _onlyBody.SetActive(true);
        }
        else if (_legsAlreadyChanged == true && _withWeapon != true)
        {
            spriteRenderer.sprite = notHoldingGun;
            Transform animationTransform = transform.Find("Animation");
            animationTransform.transform.position = transform.position + new Vector3(0, 0, 0);
            _onlyBody.SetActive(false);
        }
    }


}
