using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enumeració dels diferents estats del joc
public enum GameState
{
    Exploration,
    Inventory,
    Puzzle,
    StoryMode
}

public class GameStateManager : MonoBehaviour
{
    private GameState currentState;
    private UIManager uiManager;

    // Propietat per accedir a l'estat actual
    public GameState CurrentState
    {
        get { return currentState; }
        set { SetState(value); }
    }

    void Start()
    {
        // Inicialitza l'estat inicial, per exemple, StoryMode
        uiManager = FindObjectOfType<UIManager>();
        SetState(GameState.StoryMode);
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("GameState: " + currentState); // Seguiment dels estats del joc

        // Sortida per a l'estat actual
        switch (currentState)
        {
            case GameState.Exploration:
                // Activa Moviment del jugador.
                EnableExploration();
                break;
            case GameState.Inventory:
                // Activa la UI de l'inventari, i Menu del joc
                EnableInventory();
                break;
            case GameState.Puzzle:
                // Lògica dels Puzzles
                EnablePuzzle();
                break;
            case GameState.StoryMode:
                // Narrativa, Cinemàtiques, transicions
                EnableStoryMode();
                break;
        }

        // Lògica addicional per quan es canvia d'estat
    }
    
   
    private void EnableExploration()
    {
        // Mètode per activar l'estat d'exploració
        uiManager.explorationUI.SetActive(true);
    }

    private void EnableInventory()
    {
        // Mètode per activar l'estat d'inventari i anàlisi
        uiManager.inventoryUI.SetActive(true);
    }

    private void EnablePuzzle()
    {
        //Mètode per activar els Puzzles GameState
        uiManager.puzzleUI.SetActive(true);
    }

    private void EnableStoryMode()
    {
        //Mètode per activar la narrativa
        uiManager.storyModeUI.SetActive(true);
    }


    // Actualització d'estats
    void Update()
    {
        switch (currentState)
        {
            case GameState.Exploration:
                //Activa la navegació de l'usuari per l'escena
                uiManager.explorationUI.SetActive(true);
                break;
            case GameState.Inventory:
                //Activa la UI del MenuInventari
                uiManager.inventoryUI.SetActive(true);
                break;
            case GameState.Puzzle:
                //Activa la UI dels Puzzles GameState
                uiManager.puzzleUI.SetActive(true);
                break;
            case GameState.StoryMode:
                //Activa la UI narrativa
                uiManager.storyModeUI.SetActive(true);
                break;
        }
    }
    
}



