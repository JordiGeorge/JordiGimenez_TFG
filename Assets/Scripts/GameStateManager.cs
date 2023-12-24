using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
    private GameState _currentState;
    [SerializeField] private UIManager _uiManager;
    public PlayableDirector _storyModeTimeline;

    // Propietat per accedir a l'estat actual
    public GameState CurrentState
    {
        get { return _currentState; }
        set { SetState(value); }
    }
    
    private void Awake()
    {
        _uiManager = GetComponent<UIManager>();
        _storyModeTimeline = GetComponent<PlayableDirector>();

    }

    void Start()
    {
        //_storyModeTimeline.GetComponent();
        SetState(GameState.StoryMode);
    }

    public void SetState(GameState newState)
    {
        _currentState = newState;
        Debug.Log("GameState: " + _currentState); // Seguiment dels estats del joc

        // Sortida per a l'estat actual
        switch (_currentState)
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

    }

    private void EnableInventory()
    {
        // Mètode per activar l'estat d'inventari i anàlisi

    }

    private void EnablePuzzle()
    {
        //Mètode per activar els Puzzles GameState
    }

    private void EnableStoryMode()
    {
        //Mètode per activar la narrativa
        _storyModeTimeline.Play(); //Activem Playable de Timeline
    }


    // Actualització d'estats
    void Update()
    {
        switch (_currentState)
        {
            case GameState.Exploration:
                //Activa la navegació de l'usuari per l'escena
                _uiManager.GameStateSwitcherUI();
                break;
            case GameState.Inventory:
                //Activa la UI del MenuInventari
                _uiManager.GameStateSwitcherUI();
                break;
            case GameState.Puzzle:
                //Activa la UI dels Puzzles GameState
                _uiManager.GameStateSwitcherUI();
                break;
            case GameState.StoryMode:
                //Activa la UI narrativa
                _uiManager.GameStateSwitcherUI();
                break;
        }
    }
    
}



