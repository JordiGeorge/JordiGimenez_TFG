using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExplorationModeManager : MonoBehaviour
{
    private StoryState _currentStoryState;
    private GameStateManager _gameStateManager; //Variable per controlar estats del joc
    private PlayerCameraSwitcher _playerControl; //Activa o desactiva capaciat de navegació
    //private UIManager _uiManager;
    private bool _isUIActive;
    
    public ItemPickup[] items; //Variable Accés a item per a mètode Pickup

    void Start()
    {
        //Busquem i assignem els components a variables
        // _uiManager = GetComponent<UIManager>();
        _gameStateManager = GetComponent<GameStateManager>();
        _playerControl = FindObjectOfType<PlayerCameraSwitcher>();
        items = FindObjectsOfType<ItemPickup>();
    }
    
    //Usem el mateix botó per entrar/sortir a Mode Exploració
    void ToggleUI()
    {
        if (!_isUIActive)
            EnterExplorationMode();
        else if (_isUIActive)
            ExitExplorationMode();
    }
    
    // Mètode per entrar a GameState Exploració
    public void EnterExplorationMode()
    {
        _gameStateManager.SetState(GameState.Exploration);
        foreach (var item in items)
        {
            item.GetComponent<ItemPickup>().enabled = true;
            item.isExplorationMode = true;
        }
        _playerControl.enabled = false;
        _isUIActive = true;
    }

    // Mètode per sortir de  GameState i tornar a Navegació
    public void ExitExplorationMode()
    {
        _gameStateManager.SetState(GameState.Navigation);
        foreach (var item in items)
        {
            item.GetComponent<ItemPickup>().enabled = false;
            item.isExplorationMode = false;
        }
        _playerControl.enabled = true;
        _isUIActive = false;
    }
}
