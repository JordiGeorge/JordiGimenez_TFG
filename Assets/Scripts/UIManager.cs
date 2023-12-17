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

    // ReSharper disable Unity.PerformanceAnalysis
    private void GameStateSwitcherUI()
    {
        if (gameStateManager == null) return; // Control, Retorna si no es troba gameStateManager

        // Tots els elements de la UI desactivats per defecte
        explorationUI.SetActive(false);
        inventoryUI.SetActive(false);
        puzzleUI.SetActive(false);
        storyModeUI.SetActive(false);

        // Activa les diferents UI en funció del GameState actual
        switch (gameStateManager.CurrentState)
        {
            case GameState.Exploration:
                gameStateManager.SetState(GameState.Exploration); // GameState Exploració
                explorationUI.SetActive(true); // Activa la UI d'Exploració
                break;
            case GameState.Inventory:
                gameStateManager.SetState(GameState.Inventory); // GameState a Inventari
                inventoryUI.SetActive(true); // Activa la UI d'Inventari
                break;
            case GameState.Puzzle:
                gameStateManager.SetState(GameState.Puzzle); // GameState a Puzzle
                puzzleUI.SetActive(true); // Activa la UI de Puzzle
                break;
            case GameState.StoryMode:
                gameStateManager.SetState(GameState.StoryMode); // GameState StoryMode
                storyModeUI.SetActive(true); // Activa la UI del StoryMode
                break;
        }
    }
}
