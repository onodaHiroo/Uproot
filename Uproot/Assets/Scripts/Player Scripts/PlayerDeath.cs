using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject playerDeathBody;
    public bool isDead = false;
    
    public void Death()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
        isDead = true;
        Instantiate(playerDeathBody, transform.position, Quaternion.identity);
    }

}
