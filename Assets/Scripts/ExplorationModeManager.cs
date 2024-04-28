using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplorationModeManager : MonoBehaviour
{
    private StoryState _currentStoryState;
    private GameStateManager _gameStateManager; //Variable per controlar estats del joc
    //private UIManager _uiManager;
    private bool _isUIActive;
    
    public ItemPickup[] items; //Variable Accés a item per a mètode Pickup

    void Start()
    {
        //Busquem i assignem els components a variables
        _isUIActive = false;
        // _uiManager = GetComponent<UIManager>();
        _gameStateManager = GetComponent<GameStateManager>();
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
        _isUIActive = false;
    }
}
