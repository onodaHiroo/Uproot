using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndDropWeapon : MonoBehaviour
{
    private GameObject _currentWeapon = null;
    private GameObject _whichWeaponWeOn = null;
    public Transform holdPoint;
    protected bool _withWeapon = false;

    public GameObject holdingGunPlayerObject;
    public GameObject notHoldingGunPlayerObject;

    public void Start()
    {
        ChangePlayerSprite();
    }

    public void FixedUpdate()
    {
        WeaponManager();
    }

    private void WeaponManager()
    {
        if (Input.GetMouseButtonDown(1) && _whichWeaponWeOn != null && _currentWeapon == null)
        {
            PickWeapon(_whichWeaponWeOn);
            _withWeapon = true;
            ChangePlayerSprite();
        }
        else if (Input.GetMouseButtonDown(1) && _whichWeaponWeOn == null && _currentWeapon != null)
        {
            DropWeapon(_currentWeapon);
            _withWeapon = false;
            ChangePlayerSprite();
        }


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Weapon")
        {
            _whichWeaponWeOn = collider.gameObject;
        }
    } 
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Weapon")
        {
            _whichWeaponWeOn = null;
        }
    }

    private void PickWeapon(GameObject weapon)
    {
        SpawnHoldingWeapon();
        Debug.Log($"Weapon {weapon} is picked");
        Destroy(_whichWeaponWeOn);
    }

    public void SpawnHoldingWeapon()
    {
        GameObject tempcurrentWeapon = Resources.Load<GameObject>($"Prefabs/Guns/Holding/holding_{_whichWeaponWeOn.name.Replace("(Clone)","")}");
        GameObject weapon = Instantiate(tempcurrentWeapon, transform.position, holdPoint.rotation);
        weapon.transform.parent = holdPoint.transform;
        _currentWeapon = weapon;
    }

    private void DropWeapon(GameObject weapon)
    {
        SpawnLyingWeapon();
        Debug.Log($"Weapon {weapon} is dropped");
        Destroy(weapon);
        _currentWeapon = null;

    }

    private void SpawnLyingWeapon()
    {
        _whichWeaponWeOn = Resources.Load<GameObject>($"Prefabs/Guns/Common/{_currentWeapon.name.Replace("holding_", "").Replace("(Clone)", "")}");
        Instantiate(_whichWeaponWeOn, transform.position, Quaternion.identity);
    }
    
    private void ChangePlayerSprite() //установка положения держащего в руках гг
    {
        if (_withWeapon)
        {
            holdingGunPlayerObject.SetActive(true);
            notHoldingGunPlayerObject.SetActive(false);
        }
        else
        {
            holdingGunPlayerObject.SetActive(false);
            notHoldingGunPlayerObject.SetActive(true);
        }
    }
}
