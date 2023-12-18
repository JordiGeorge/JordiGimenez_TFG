using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Variables per a assinar els diferents Canvas UI  a l'editor
    public GameObject explorationUI;
    public GameObject inventoryUI;
    public GameObject puzzleUI;
    public GameObject storyModeUI;

    private GameStateManager gameStateManager; //Variable per controlar els GameStates del joc

    void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        if (gameStateManager == null)
        {
            Debug.LogError("No existeix cap GameStateManager!!!"); // Comprobació de GameStateManager a l'escena
        }

        GameStateSwitcherUI(); // Actualitza la UI d'inici
    }

    void Update()
    {
        // Opcionalment, comprova els canvis d'estat aquí si poden ocórrer fora del control de UIManager
        GameStateSwitcherUI(); // Actualitza la UI a cada fotograma
    }

    // Canvi de UI segons estat
    private void GameStateSwitcherUI()
    {
        if (gameStateManager == null) return;

        // Tots els UI elements desactivats per defecte
        explorationUI.SetActive(false);
        inventoryUI.SetActive(false);
        puzzleUI.SetActive(false);
        storyModeUI.SetActive(false);

        // Activa les diferents UI segons GameState
        switch (gameStateManager.CurrentState)
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
