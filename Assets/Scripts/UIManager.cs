using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class UIManager : MonoBehaviour
{
    //Variables per a assinar els diferents Canvas UI  a l'editor
    public GameObject explorationUI;
    public GameObject inventoryUI;
    public GameObject puzzleUI;
    public GameObject storyModeUI;

    [SerializeField] private GameStateManager _gameStateManager; //Variable per controlar els GameStates del joc

    
    private void Awake()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();
    }

    void Start()
    {
        //_gameStateManager = FindObjectOfType<GameStateManager>();
        
        if (_gameStateManager == null)
        {
            Debug.LogError("No existeix cap GameStateManager!!!"); // Comprobació de GameStateManager a l'escena
        }
    }

    // Canvi de UI segons estat
    public void GameStateSwitcherUI()
    {
        if (_gameStateManager == null) return;

        // Tots els UI elements desactivats per defecte
        explorationUI.SetActive(false);
        inventoryUI.SetActive(false);
        puzzleUI.SetActive(false);
        storyModeUI.SetActive(false);

        // Activa les diferents UI segons GameState
        switch (_gameStateManager.CurrentState)
        {
            case GameState.Exploration:
                explorationUI.SetActive(true);
                break;
            case GameState.Inventory:
                inventoryUI.SetActive(true);
                break;
            case GameState.Puzzle:
                puzzleUI.SetActive(true);
                break;
            case GameState.StoryMode:
                storyModeUI.SetActive(true);
                break;
        }
    }
}
