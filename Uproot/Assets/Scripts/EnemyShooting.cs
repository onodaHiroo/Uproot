using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject _soundOfShot;
    public float bulletForce = 60f;

    public void EnemyShoot()
    {
        GameObject shotSound = Instantiate(_soundOfShot, transform.position, Quaternion.identity);
        Destroy(shotSound, 2f);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 2f);

        GetComponentInParent<EnemyAI>()._timerFire = 0;
    }
}
