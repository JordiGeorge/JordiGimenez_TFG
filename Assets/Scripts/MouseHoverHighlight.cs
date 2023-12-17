using UnityEngine;


//Funcionalitat que permet detectar objectes clau en l'escenari mitjançant el Mouse en el mode Exploració
public class MouseHoverHighlight : MonoBehaviour
{
    public Material highlightMaterial; // Material per aplicar quan un objecte està sota el cursor
    private Material originalMaterial; // Per emmagatzemar el material original de l'objecte assenyalat
    private Renderer renderer; // Renderer de l'objecte actualment assenyalat
    private GameObject lastHovered; // Darrer objecte que ha estat assenyalat

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Crea un raig des de la càmera fins a la posició del cursor

        if (Physics.Raycast(ray, out hit)) // Realitza un raycast per detectar si col·lisiona amb un objecte
        {
            // Comprova si objecte assenyalat anteriorment és diferent de l'objecte actual
            if (lastHovered != null && lastHovered != hit.collider.gameObject)
            {
                ResetHighlight(); // Restableix el ressaltat de l'objecte anterior
            }

            // Comprova si l'objecte actual és diferent de l'últim objecte assenyalat
            if (hit.collider.gameObject != lastHovered)
            {
                lastHovered = hit.collider.gameObject; // Actualitza l'últim objecte assenyalat
                renderer = lastHovered.GetComponent<Renderer>(); // Mesh renderer de l'objecte actual

                if (renderer != null)
                {
                    originalMaterial = renderer.material; // Material original
                    renderer.material = highlightMaterial; // Aplica el material Fresnel
                }
            }
        }
        else
        {
            ResetHighlight(); // Si el raycast no col·lisiona amb cap objecte, restableix qualsevol ressaltat existent
        }
    }

    void ResetHighlight()
    {
        // Restableix el ressaltat de l'objecte
        if (renderer != null)
        {
            renderer.material = originalMaterial; // Restaura el material original
            renderer = null; // Reset del renderer
            lastHovered = null; // reset de l'últim objecte assenyalat
        }
    }
}
