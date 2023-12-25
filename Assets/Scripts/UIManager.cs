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
    public GameObject[] storyModeStates;

    GameStateManager _gameStateManager; //Variable per controlar els GameStates del joc
    
    private void Awake()
    {
        if (_gameStateManager == null)
        {
            Debug.LogError("No existeix cap GameStateManager!!!"); // Comprobació de GameStateManager a l'escena
        }
        
        _gameStateManager = GetComponent<GameStateManager>(); //Assignem component
        
        if (storyModeUI != null)
        {
            //Nova llista per buscar els fills del GameObject storyModeUI;
            List<GameObject> children = new List<GameObject>();
            
            foreach (Transform child in storyModeUI.transform)
            {
                children.Add(child.gameObject); //Afegim a la llista els GameObjects trobats en el loop
            }
            storyModeStates = children.ToArray();  //Afegim elements de la llista a l'array storyModeStates
        }
        else
        {
            Debug.LogError("storyModeUI no esta assignat!"); //Control
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
    
    // Mètode que en permet activar i desactivar GameObjects dins de StoreModeUI
    public void StoryStateUISwitcher(StoryState state)
    {
        foreach (GameObject uiState in storyModeStates)
        {
            uiState.SetActive(uiState.name == state.ToString()); //Activem GameObject corresponent a la UI En funció del nom Enum StoryState
        }
    }
}
