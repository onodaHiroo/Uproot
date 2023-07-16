using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StunTimerScript : MonoBehaviour
{
    public Enemy enemy;
    public float stunTime;
    public GameObject enemyStunned;
    public GameObject enemyUnStunAnim;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Stun time: {stunTime} sec");
        //stunTime += Time.deltaTime * 2;
        enemy.ifStunTimerIsOver = false;
        Invoke("PlayAnimOfEnemyUnStun", stunTime - 1.0f);
    }

    void Update()
    {
        stunTime -= Time.deltaTime;
        UnStunEnemy();
    }

    void PlayAnimOfEnemyUnStun()
    {
        Destroy(enemyStunned.gameObject);
        GameObject enemyUnStunned = Instantiate(enemyUnStunAnim, transform.position, transform.rotation);
        Destroy(enemyUnStunned, 2f);
    }

    private void UnStunEnemy()
    {
        if (stunTime <= 0)
        {
            enemy.gameObject.SetActive(true);
            enemy.ifStunTimerIsOver = true;
            Destroy(gameObject);
            
        }
    }


}
