using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

// Enumeració dels diferents estats del joc
public enum GameState
{
    Navigation,
    Exploration,
    Inventory,
    Puzzle,
    StoryMode
}

public class GameStateManager : MonoBehaviour
{
    private GameState _currentState;
    private UIManager _uiManager;
    private StoryModeManager _storyManager;
    private DevelopUI _developUI;
    
    //Proves amb Timeline
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
        _storyManager = GetComponent<StoryModeManager>();
        _developUI = GetComponent<DevelopUI>();
        
       _storyModeTimeline = GetComponent<PlayableDirector>();//Proves amb Timeline
    }

    void Start()
    {
        //_storyModeTimeline.GetComponent();
        SetState(GameState.StoryMode);
        _storyManager.SetStoryState(StoryState.Introduction);
        
        //_storyModeTimeline.playableAsset = _storyManager.timelineAsset; //Proves amb Timeline
    }

    public void SetState(GameState newState)
    {
        _currentState = newState;
        Debug.Log("GameState: " + _currentState); // Seguiment dels estats del joc

        // Sortida per a l'estat actual
        switch (_currentState)
        {
            case GameState.Navigation:
                // Activa Moviment del jugador.
                EnableNavigation();
                break;
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
    
    private void EnableNavigation()
    {
        // Mètode per activar l'estat de navegació

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
        _storyModeTimeline.Play(); //Activem Playable de Timeline (Proves amb Timeline)
    }
    
    // Actualització d'estats
    void Update()
    {
        switch (_currentState)
        {
            case GameState.Navigation:
                //Activa la navegació de l'usuari per l'escena
                _uiManager.GameStateSwitcherUI();
                _developUI.InfoDevelopUI();
                break;
            case GameState.Exploration:
                //Activa la explorarció de l'usuari per l'escena
                _uiManager.GameStateSwitcherUI();
                _developUI.InfoDevelopUI();
                break;
            case GameState.Inventory:
                //Activa la UI del MenuInventari
                _uiManager.GameStateSwitcherUI();
                _developUI.InfoDevelopUI();
                break;
            case GameState.Puzzle:
                //Activa la UI dels Puzzles GameState
                _uiManager.GameStateSwitcherUI();
                _developUI.InfoDevelopUI();
                break;
            case GameState.StoryMode:
                //Activa la UI narrativa
                _uiManager.GameStateSwitcherUI();
                _developUI.InfoDevelopUI();
                break;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    
    //Tanca aplicació a editor i a Build
    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Si estás al editor
        #else
                Application.Quit(); // Si estás a Build
        #endif
    }
}





