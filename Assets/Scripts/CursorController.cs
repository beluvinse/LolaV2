using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public Texture2D cursorAim;

    private void Start()
    {
        Cursor.SetCursor(cursorAim, Vector3.zero, CursorMode.ForceSoftware);
    }

}
