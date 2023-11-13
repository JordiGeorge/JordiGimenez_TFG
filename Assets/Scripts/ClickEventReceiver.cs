using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventReceiver : MonoBehaviour
{
    // Declare a method that will be called when the UnityEvent is received
    public void OnClickReceived( )
    {
        // Add your response here. For example, you could play a sound or animate the game object
        Debug. Log( "Received Unity Event!");
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = this.transform.position;
    }
}
