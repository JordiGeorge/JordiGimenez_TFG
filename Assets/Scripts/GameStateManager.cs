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
    [SerializeField]
    private GameState _currentState;
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private StoryModeManager _storyManager;
    [SerializeField]
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
    }

    void Start()
    {
        SetState(GameState.StoryMode);
        _storyManager.SetStoryState(StoryState.Introduction);
        _storyModeTimeline.Play(); //Activem Playable de Timeline (Proves amb Timeline)
    }

    public void SetState(GameState newState)
    {
        _currentState = newState;
        Debug.Log("GameState: " + _currentState); // Seguiment dels estats del joc
    }
    
    // Actualització d'estats
    void Update()
    {
        _developUI.InfoDevelopUI();
        _uiManager.GameStateSwitcherUI();

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





