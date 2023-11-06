using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeadBodyManager : MonoBehaviour
{
    //singleton

    public static DeadBodyManager instance { get; private set; } = null;
    public Sprite[] enemyDeadBodies;
    public Sprite[] playerDeadBodies;
    public GameObject[] bloodSplashAnims = new GameObject[4];

    void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
        else
        {
            Destroy(this); 
        }
        //InitializeSpawner();
    }

    public Sprite GetDeadBodySprite(GameObject entity)
    {
        Sprite[] array = null;

        if (entity.tag == "Enemy")
        {
            array = enemyDeadBodies;
        }
        else if (entity.tag == "Player")
        {
            array = playerDeadBodies;
        }

        var rand = UnityEngine.Random.Range(0, array.Length);
        Sprite deadSprite = array[rand];
        Debug.Log($"Выбран {rand} мертвый спрайт для {entity.name}");

        return deadSprite;
    }

    //private void InitializeSpawner()
    //{
    //    //enemyDeadBodies = new Sprite[enemyDeadBodies.Length];
    //    //playerDeadBodies = new Sprite[playerDeadBodies.Length];

    //    Debug.Log($"Создан {enemyDeadBodies}, длиной {enemyDeadBodies.Length}");        
    //    Debug.Log($"Создан {playerDeadBodies}, длиной {playerDeadBodies.Length}");

    //    DisplayList(enemyDeadBodies);
    //    DisplayList(playerDeadBodies);
    //}

    //private void AddToSpawner(Sprite sprite, Sprite[] list)
    //{
    //    for (int i = 0; i < list.Length; i++)
    //    {
    //        if (enemyDeadBodies[i] == null)
    //        {
    //            enemyDeadBodies[i] = sprite;
    //            Debug.Log($"{sprite} was added to {enemyDeadBodies}");
    //            break;
    //        }
    //    }
    //}

    private void DisplayList(Sprite[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Debug.Log($"{enemyDeadBodies[i]}");
        }
    }

    public GameObject GetBloodSplashGameObject()
    {
        GameObject[] array = bloodSplashAnims;
        var rand = UnityEngine.Random.Range(0, array.Length);
        GameObject bloodSplash = array[rand];

        return bloodSplash;
    }

}
