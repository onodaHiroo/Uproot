using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckColliderForShooting : MonoBehaviour
{
    [SerializeField]
    private string _wallCheck;
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        _player = FindObjectOfType<Punching>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _wallCheck = collider.gameObject.tag;
        if (_player.GetComponent<TakeAndDropWeapon>().currentWeapon != null)
            _weapon = _player.GetComponent<TakeAndDropWeapon>().currentWeapon.gameObject;

        if (collider.gameObject.tag == "Wall" && _weapon != null)
        {
            _weapon.GetComponentInChildren<Shooting>().wallCheckingTag = _wallCheck;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        _wallCheck = null;
        if (collider.gameObject.tag == "Wall" && _weapon != null)
        {
            _weapon.GetComponentInChildren<Shooting>().wallCheckingTag = null;
        }
    }
}
