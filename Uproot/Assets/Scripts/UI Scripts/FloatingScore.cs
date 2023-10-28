using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingScore : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    public int score = 500;

    private void Start()
    {
        if (gameObject.GetComponent<TextMeshPro>() != null)
        {
            textMeshPro = GetComponent<TextMeshPro>();
            textMeshPro.text = $"+{score}";
        }
        
    }

    public void OnAnimationOver()
    {
        Destroy(gameObject.transform.parent.gameObject); //seems it can be :)
    }
}
