
using UnityEngine;


//Classe per visualitzar el cursor i canviar la seva aparença
public class CustomCursor : MonoBehaviour
{
    public Texture2D customCursorTexture;

    void Start()
    {
        // Vector2.zero (Hotspot top-left corner of the image)
        Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
    }
}