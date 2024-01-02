using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationModeManager : MonoBehaviour
{
    private StoryState _currentStoryState;
    private GameStateManager _gameStateManager; //Variable per controlar estats del joc
    private PlayerCameraSwitcher _playerControl; //Activa o desactiva capaciat de navegació
    private UIManager _uiManager;
    
    public Item item; //Variable Accés a item per a mètode Pickup
    
    //Tintem color del objecte de vermell quan el mouse esta a sobre (hover)
    Color mouseOverColor = Color.red;
    Color originalColor;

    // Variables pels components mesh and sprite renderer 
    MeshRenderer meshRenderer;
    SpriteRenderer spriteRenderer;
    
    void Awake()
    {
        _uiManager = GetComponent<UIManager>();
        _gameStateManager = GetComponent<GameStateManager>();
        _playerControl = FindObjectOfType<PlayerCameraSwitcher>();
    }

    void Start()
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
            originalColor = spriteRenderer.color;  //Assignem el color del sprite
        }

        if (meshRenderer == null && spriteRenderer == null)
        {
            Debug.LogWarning("No MeshRenderer o SpriteRenderer trobat a l'objecte.");
        }
    }
    
    // Mètode per entrar a GameState StoryMode
    public void EnterExplorationMode()
    {
        _gameStateManager.SetState(GameState.Exploration);
        DisablePlayerControls();
    }

    // Mètode per sortir de  GameState StoryMode i tornar a Exploració
    public void ExitExplorationMode()
    {
        _gameStateManager.SetState(GameState.Navigation);
        EnablePlayerControls(); 
    }

    // Mètode per desactivar habilitat per nevegar de l'usuri
    private void DisablePlayerControls()
    {
        // La lògica per desactivar els controls del jugador va aquí
        _playerControl.enabled = false;
    }
    // Mètode per activar habilitat per nevegar de l'usuri
    private void EnablePlayerControls()
    {
        // La lògica per activar els controls del jugador va aquí
        _playerControl.enabled = true;
    }
    
    private void OnMouseDown()
    {
        PickUp();
    }

    private void OnMouseOver()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.color = mouseOverColor;
        }
        else if (spriteRenderer != null)
        {
            spriteRenderer.color = mouseOverColor;
        }
        
        Debug.Log("Name: " + gameObject.name);
    }

    private void OnMouseExit()
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
    
    // Mètode per afegir Item a la llista de l'inventari i eliminar objecte de l'escena
    public void PickUp ()
    {
        Debug.Log("Item " + item.name); //Control
		
        Inventory.instance.Add(item);// afegir a llista inventory
        Destroy(gameObject);// Eliminem objecte de l'escena
    }
}
