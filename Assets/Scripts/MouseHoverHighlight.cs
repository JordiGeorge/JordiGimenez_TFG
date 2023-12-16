using UnityEngine;

public class MouseHoverHighlight : MonoBehaviour
{
    public Material highlightMaterial;
    private Material originalMaterial;
    private Renderer renderer;
    private GameObject lastHovered;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (lastHovered != null && lastHovered != hit.collider.gameObject)
            {
                ResetHighlight();
            }

            if (hit.collider.gameObject != lastHovered)
            {
                lastHovered = hit.collider.gameObject;
                renderer = lastHovered.GetComponent<Renderer>();
                if (renderer != null)
                {
                    originalMaterial = renderer.material;
                    renderer.material = highlightMaterial;
                }
            }
        }
        else
        {
            ResetHighlight();
        }
    }

    void ResetHighlight()
    {
        if (renderer != null)
        {
            renderer.material = originalMaterial;
            renderer = null;
            lastHovered = null;
        }
    }
}