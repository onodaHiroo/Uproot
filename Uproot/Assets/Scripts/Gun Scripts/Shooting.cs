using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    public GameObject _soundOfShot;

    public float bulletForce = 60f;
    public static int bulletAmmo;

    private float _period = 0.1f;
    private float _timerFire;

    public string wallCheckingTag;

    private GameObject _cam;

    void Start()
    {
        _timerFire = _period;
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        AmmoTextUi.ammoBullets = bulletAmmo;

        if (Input.GetAxis("Fire1") > 0 && _timerFire >= _period )
        {
            if (bulletAmmo > 0)
            {
                this.Shoot();
                //Camera shake while shooting
                _cam.GetComponent<CameraShakeEffect>().StartShaking(1, new Vector2(0.3f, 0.3f));
            }  
        }
        _timerFire += Time.deltaTime;
    }

    private void Shoot()
    {
        if (wallCheckingTag is "Wall")
        {
            SoundOfShot();

            bulletAmmo -= 1;
            _timerFire = 0;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            SoundOfShot();

            

            Destroy(bullet, 2f);

            bulletAmmo -= 1;
            _timerFire = 0;
        }
    }

    private void SoundOfShot()
    {
        GameObject shotSound = Instantiate(_soundOfShot, transform.position, Quaternion.identity);
        Destroy(shotSound, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        wallCheckingTag = collider.gameObject.tag;

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        wallCheckingTag = null;
    }
}
