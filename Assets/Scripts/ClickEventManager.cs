using UnityEngine;
using UnityEngine.Events;

public class ClickEventManager : MonoBehaviour
{
    public UnityEvent onClick;

    private void Awake()
    {
        // Inicialitza l'Event i afegeix un mètode AddListener
        if (onClick == null)
            onClick = new UnityEvent();

        onClick.AddListener(OnClickReceived);
    }

    private void OnMouseDown()
    {
        // Invoca l'Event quan es fa click en l'objecte (aquest requereix Collider 'Trigger')
        onClick.Invoke();
    }

    private void OnClickReceived()
    {
        //Acció a realitzar quan en l'objecte clickat (l'objecte requereix Collider 'Trigger')
        Debug.Log("Missatge rebut");

        // Crea una esfera temporal a mode test. 
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(8,0,-6);
    }
}


