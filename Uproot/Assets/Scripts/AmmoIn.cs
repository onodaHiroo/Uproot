using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoIn : MonoBehaviour
{
    public int ammoInsideGun;
    public int sizeOfClip;

    void Start()
    {
        if(gameObject.name == "OMFGUN")
        {
            ammoInsideGun = 20;
            sizeOfClip = 20;
        }
        if(gameObject.name == "AK")
        {
            ammoInsideGun = 10;
            sizeOfClip = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
