using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. Events;
public class ClickEventSender : MonoBehaviour
{
// Declare a UnityEvent that can be called when the game object is clicked
    public UnityEvent onClick;
    private void OnMouseDown ( )
    {
    // Call the UnityEvent when the game object is clicked
        onClick. Invoke();
    }
}
