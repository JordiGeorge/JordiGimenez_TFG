using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Variables per a assinar els diferents Canvas UI  a l'editor
    public GameObject gameStatesHUD;
    public GameObject menuInventoryHUD;
    public GameObject exitHUD;
    public GameObject navigationUI;
    public GameObject explorationUI;
    public GameObject menuInventoryUI;
    public GameObject menuExitUI;
    public GameObject puzzleUI;
    public GameObject storyModeUI;
    public GameObject[] storyModeStates;

    GameManager _gameStateManager; //Variable per controlar els GameStates del joc
    
    private void Awake()
    {
        _gameStateManager = GetComponent<GameManager>(); //Assignem component
        
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
            Debug.LogError("storyModeUI no esta assignat!"); // Control
        }
    }

    // Canvi de UI segons estat
    public void GameStateSwitcherUI(GameState gameState)
    {
        if (_gameStateManager == null) return;

        _gameStateManager.SetState(gameState);

        // Activa les diferents UI segons GameState
        switch (gameState)
        {
            case GameState.Navigation:
                gameStatesHUD.SetActive(true);
                menuInventoryHUD.SetActive(true);
                exitHUD.SetActive(true);
                menuExitUI.SetActive(false);
                navigationUI.SetActive(true);
                explorationUI.SetActive(false);
                menuInventoryUI.SetActive(false);
                puzzleUI.SetActive(false);
                storyModeUI.SetActive(false);
                break;
            case GameState.Exploration:
                gameStatesHUD.SetActive(true);
                menuInventoryHUD.SetActive(true);
                exitHUD.SetActive(true);
                menuExitUI.SetActive(false);
                explorationUI.SetActive(true);
                navigationUI.SetActive(false);
                menuInventoryUI.SetActive(false);
                puzzleUI.SetActive(false);
                storyModeUI.SetActive(false);
                break;
            case GameState.MenuInventory:
                gameStatesHUD.SetActive(false);
                menuInventoryHUD.SetActive(true);
                exitHUD.SetActive(false);
                menuExitUI.SetActive(false);
                menuInventoryUI.SetActive(true);
                explorationUI.SetActive(false);
                navigationUI.SetActive(false);
                puzzleUI.SetActive(false);
                storyModeUI.SetActive(false);
                break;
            case GameState.ExitMenu:
                gameStatesHUD.SetActive(false);
                menuInventoryHUD.SetActive(false);
                exitHUD.SetActive(false);
                menuExitUI.SetActive(true);
                menuInventoryUI.SetActive(false);
                explorationUI.SetActive(false);
                navigationUI.SetActive(false);
                puzzleUI.SetActive(false);
                storyModeUI.SetActive(false);
                break;
            case GameState.Puzzle:
                gameStatesHUD.SetActive(true);
                menuInventoryHUD.SetActive(true);
                exitHUD.SetActive(true);
                menuExitUI.SetActive(false);
                puzzleUI.SetActive(true);
                explorationUI.SetActive(false);
                navigationUI.SetActive(false);
                menuInventoryUI.SetActive(false);
                storyModeUI.SetActive(false);
                break;
            case GameState.StoryMode:
                gameStatesHUD.SetActive(false);
                menuInventoryHUD.SetActive(false);
                exitHUD.SetActive(false);
                menuExitUI.SetActive(false);
                storyModeUI.SetActive(true);
                explorationUI.SetActive(false);
                navigationUI.SetActive(false);
                menuInventoryUI.SetActive(false);
                puzzleUI.SetActive(false);
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
