using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour 
{
    public Item item; //Variable Accés a item per a mètode Pickup
    private UIManager _uiManager;
    private TextMeshProUGUI textToChange; // Variable de tipus TextMeshProUGUI
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
            _uiManager = FindFirstObjectByType<UIManager>();
            textToChange = _uiManager.explorationUI.GetComponentInChildren<TextMeshProUGUI>();
            
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
            
            textToChange.text = item.name;
        }
    }

    private void OnMouseExit()
    {
        if (isExplorationMode)
        {
            if (meshRenderer != null)
            {
                meshRenderer.material.color = originalColor;
                textToChange.text = null; textToChange.text = null; //Reset de la UI d'exploracio
            }
            else if (spriteRenderer != null)
            {
                spriteRenderer.color = originalColor;
                textToChange.text = null; textToChange.text = null; //Reset de la UI d'exploracio
            }
        }
    }
    
    
	// Mètode per afegir Item a la llista de l'inventari i eliminar objecte de l'escena
	public void PickUp ()
	{
        if (isExplorationMode)
        {
            Debug.Log("Item " + item.name); //Control

            textToChange.text = null; //Reset de la UI d'exploracio
            Inventory.instance.Add(item); // afegir a llista inventory
            Destroy(gameObject); // Eliminem objecte de l'escena
        }
    }
	
}
