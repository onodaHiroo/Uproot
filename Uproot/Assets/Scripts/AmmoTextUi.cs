using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextUi : MonoBehaviour
{
    Text text;
    public static int ammoBullets = 0;
    public static int sizeClip = 0;
    public static bool checkIfWithWeapon;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        checkIfWithWeapon = TakeAndDropWeapon.withWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoBullets == 0 && sizeClip == 0 && checkIfWithWeapon == false)
        {
            text.text = "";
        }
        else
        {
            text.text = $"{ammoBullets}/{sizeClip}";
        }
    }
}
