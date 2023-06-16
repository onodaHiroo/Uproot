using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTimerScript : MonoBehaviour
{
    public Enemy enemy;
    public float stunTime;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Stun time: {stunTime} sec");
        //stunTime += Time.deltaTime * 2;
    }

    void Update()
    {
        stunTime -= Time.deltaTime;
        UnStunEnemy();
    }

    private void UnStunEnemy()
    {
        if (stunTime <= 0)
        {
            enemy.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }


}
