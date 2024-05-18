using TMPro;
using UnityEngine;

public class ItemPickup : MonoBehaviour 
{
    public Item item; //Variable Accés a item per a mètode Pickup
    private UIManager _uiManager;
    private TextMeshProUGUI _textToChange; // Variable de tipus TextMeshProUGUI
    public bool isExplorationMode;
    
    //Tintem color del objecte de vermell quan el mouse esta a sobre (hover)
    private Color _mouseOverColor = Color.red;
    private Color _originalColor;

    // Variables pels components mesh and sprite renderer 
    private MeshRenderer _meshRenderer;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _uiManager = FindFirstObjectByType<UIManager>();
    }

    void Start()
    {
        if (isExplorationMode)
        {
            _textToChange = _uiManager.explorationUI.GetComponentInChildren<TextMeshProUGUI>();
            
            //Intent d'obtenir el component MeshRenderer
            _meshRenderer = GetComponent<MeshRenderer>();
            if (_meshRenderer != null)
            {
                _originalColor = _meshRenderer.material.color; //Assignem el color del material mesh renderer
            }

            //Intent d'obtenir el component MeshRenderer
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if (_spriteRenderer != null)
            {
                _originalColor = _spriteRenderer.color; //Assignem el color del sprite
            }

            if (_meshRenderer == null && _spriteRenderer == null)
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
            if (_meshRenderer != null)
            {
                _meshRenderer.material.color = _mouseOverColor;
            }
            else if (_spriteRenderer != null)
            {
                _spriteRenderer.color = _mouseOverColor;
            }
            
            _textToChange.text = item.name;
        }
    }

    private void OnMouseExit()
    {
        if (isExplorationMode)
        {
            if (_meshRenderer != null)
            {
                _meshRenderer.material.color = _originalColor;
                _textToChange.text = null; //Reset de la UI d'exploracio
            }
            else if (_spriteRenderer != null)
            {
                _spriteRenderer.color = _originalColor;
                _textToChange.text = null;//Reset de la UI d'exploracio
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
            gameObject.SetActive(false);
            _textToChange.text = null; //Reset de la UI d'exploracio
        }
    }
}
