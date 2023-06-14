using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 60f;
    public static int bulletAmmo;

    private float Period = 0.1f;
    private float timerFire;

    void Start()
    {
        timerFire = Period;
    }

    // Update is called once per frame
    void Update()
    {
        AmmoTextUi.ammoBullets = bulletAmmo;

        if (Input.GetAxis("Fire1") > 0 && timerFire >= Period)
        {
            if (bulletAmmo > 0)
            {
                Shoot();
            }  
        }
        timerFire += Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 2f);

        bulletAmmo -= 1;
        timerFire = 0;
    }
}
