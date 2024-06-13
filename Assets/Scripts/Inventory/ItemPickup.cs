using TMPro;
using UnityEngine;

public class ItemPickup : MonoBehaviour 
{
    public Item item; //Variable Accés a item per a mètode Pickup
    private UIManager _uiManager;
    private GameManager _gameStateManager;
    private TextMeshProUGUI _textToChange; // Variable de tipus TextMeshProUGUI
    
    //Tintem color del objecte de vermell quan el mouse esta a sobre (hover)
    private Color _mouseOverColor = Color.red;
    private Color _originalColor;

    // Variables pels components mesh and sprite renderer 
    private MeshRenderer _meshRenderer;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _uiManager = FindFirstObjectByType<UIManager>();
        _gameStateManager = FindFirstObjectByType<GameManager>();
        
        _meshRenderer = GetComponent<MeshRenderer>();
        if (_meshRenderer != null)
        {
            _originalColor = _meshRenderer.material.color; //Assignem el color del material mesh renderer
        }
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer != null)
        {
            _originalColor = _spriteRenderer.color; //Assignem el color del sprite
        }
    }
        
    private void OnMouseDown()
    {
        if (_gameStateManager.CurrentState == GameState.Exploration)
        {
            PickUp();
        }
    }

    private void OnMouseOver()
    {
        
        if (_gameStateManager.CurrentState == GameState.Exploration)
        {
            _textToChange = _uiManager.explorationUI.GetComponentInChildren<TextMeshProUGUI>();
            
            if (_meshRenderer != null)
            {
                _meshRenderer.material.color = _mouseOverColor;
            }
            else if (_spriteRenderer != null)
            {
                _spriteRenderer.color = _mouseOverColor;
            }
            
            _textToChange.text = gameObject.name;
        }
    }

    private void OnMouseExit()
    {
        if (_gameStateManager.CurrentState == GameState.Exploration)
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
        if (_gameStateManager.CurrentState == GameState.Exploration)
        {
            Debug.Log("Item " + item.name); //Control
            Inventory.instance.Add(item); // afegir a llista inventory
            gameObject.SetActive(false);
            _textToChange.text = null; //Reset de la UI d'exploracio
        }
    }
}
