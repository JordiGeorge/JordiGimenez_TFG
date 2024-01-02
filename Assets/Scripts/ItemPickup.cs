using System;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour 
{
    public Item item; //Variable Accés a item per a mètode Pickup

    public bool isExplorationMode;
    
    //Tintem color del objecte de vermell quan el mouse esta a sobre (hover)
    Color mouseOverColor = Color.red;
    Color originalColor;

    // Variables pels components mesh and sprite renderer 
    MeshRenderer meshRenderer;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        if (isExplorationMode)
        {
            //Intent d'obtenir el component MeshRenderer
            meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                originalColor = meshRenderer.material.color; //Assignem el color del material mesh renderer
            }

            //Intent d'obtenir el component MeshRenderer
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                originalColor = spriteRenderer.color; //Assignem el color del sprite
            }

            if (meshRenderer == null && spriteRenderer == null)
            {
                Debug.LogWarning("No MeshRenderer o SpriteRenderer trobat a l'objecte.");
            }
        }
    }
        
    private void OnMouseDown()
    {
        if (isExplorationMode)
        {
            PickUp();
        }
    }
    
   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Name: " + other.name);
    }*/

    private void OnMouseOver()
    {
        if (isExplorationMode)
        {
            if (meshRenderer != null)
            {
                meshRenderer.material.color = mouseOverColor;
            }
            else if (spriteRenderer != null)
            {
                spriteRenderer.color = mouseOverColor;
            }
        }
    }

    private void OnMouseExit()
    {
        if (isExplorationMode)
        {
            if (meshRenderer != null)
            {
                meshRenderer.material.color = originalColor;
            }
            else if (spriteRenderer != null)
            {
                spriteRenderer.color = originalColor;
            }
        }
    }
    
    
	// Mètode per afegir Item a la llista de l'inventari i eliminar objecte de l'escena
	public void PickUp ()
	{
        if (isExplorationMode)
        {
            Debug.Log("Item " + item.name); //Control

            Inventory.instance.Add(item); // afegir a llista inventory
            Destroy(gameObject); // Eliminem objecte de l'escena
        }
    }
	
}
