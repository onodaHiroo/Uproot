using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 60f;
    public static int bulletAmmo;

    // Update is called once per frame
    void Update()
    {
        AmmoTextUi.ammoBullets = bulletAmmo;

        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletAmmo > 0)
            {
                Shoot();
            }  
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 2f);

        bulletAmmo -= 1;
    }
}
