using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTexture : MonoBehaviour
{
    public Texture2D point;
    Texture2D grab;
    public Texture2D open;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.SetCursor(point, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
