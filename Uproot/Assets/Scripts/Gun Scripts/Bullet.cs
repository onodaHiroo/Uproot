    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float Damage = 100;

    public GameObject hitWallEffect;
    public GameObject hitEnemyEffect;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall")
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(hitWallEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Debug.Log($"You hitted a wall named {collision.collider}");
        }

        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(hitEnemyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerDeath>().Death();
            //GameObject player = GameObject.FindGameObjectWithTag("Player");
            //player.SetActive(false);
        }

        if (collision.transform.tag == "Bullet")
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(hitWallEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

        if (collision.transform.tag != "Wall" && collision.transform.tag != "Player" && collision.transform.tag != "Bullet") //колхоз но похуй 2 ночи уже
        {
            Destroy(gameObject);
        }

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Enemy")
        {
            Enemy enemy = collider.transform.GetComponent<Enemy>();

            GameObject effect = Instantiate(hitEnemyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);

            Debug.Log($"You hitted {enemy}");
            if (enemy != null)
            {
                Destroy(gameObject);
                enemy.TakeDamage(Damage);
            }
            Destroy(gameObject);

        }
    }
}
