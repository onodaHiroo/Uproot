using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursorTextureEnemy;
    public Texture2D cursorTextureCel;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = new Vector2(17.5f, 14.0f);// + new Vector2(0.175f, 0.140f);

    public bool game, menu;

    // Start is called before the first frame update
    void Start()
    {
        if (game && cursorTextureCel != null && cursorTextureEnemy != null)
        {
            Cursor.SetCursor(cursorTextureCel, hotSpot, cursorMode); 
        }
        if (menu)
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }

    public void ToEnemyEnter()
    {
        Cursor.SetCursor(cursorTextureEnemy, hotSpot, cursorMode);
    }

    public void ToEnemyExit()
    {
        Cursor.SetCursor(cursorTextureCel, hotSpot, cursorMode);
    }
}
