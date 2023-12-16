using UnityEngine;
using UnityEngine.Events;

public class ClickEventManager : MonoBehaviour
{
    public UnityEvent onClick;

    private void Awake()
    {
        // Initialize the UnityEvent and add a listener method to it
        if (onClick == null)
            onClick = new UnityEvent();

        onClick.AddListener(OnClickReceived);
    }

    private void OnMouseDown()
    {
        // Invoke the UnityEvent when the GameObject is clicked
        onClick.Invoke();
    }

    private void OnClickReceived()
    {
        // Action to be taken when the GameObject is clicked
        Debug.Log("Received Unity Event!");

        // Create a sphere at the position of this GameObject
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = this.transform.position;
    }
}

