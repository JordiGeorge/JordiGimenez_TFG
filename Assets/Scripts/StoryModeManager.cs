using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

//Enum per controlar estats del joc
public enum StoryState
{
    Introduction,
    MainStreet,
    RightSideStreet,
    LeftSideStreet,
    Alley,
    ToBeContinued
}

//Classe per controlar progrés de la història
public class StoryModeManager : MonoBehaviour
{
    private StoryState _currentStoryState;
    private GameStateManager _gameStateManager; //Variable per controlar estats del joc
    private PlayerCameraSwitcher _playerControl; //Activa o desactiva capaciat de navegació
    private UIManager _uiManager;
    
    //Funcionalitats Timeline (WIP)
    public PlayableDirector _storyModeTimeline;
    public TimelineAsset timelineAsset;
    
    // Propietat de la classe pel control de la història actual
    public StoryState CurrentStoryState
    {
        get { return _currentStoryState; }
        set { SetStoryState(value); }
    }
    
    //Mètode per setejar els estats del progrés de la història
    public void SetStoryState(StoryState newState)
    {
        _currentStoryState = newState;
        Debug.Log("StoryState: " + _currentStoryState); // Seguiment del progrés de la història

        // Sortida per a l'estat de la història actual
        switch (_currentStoryState)
        {
            case StoryState.Introduction:
                // Activa Intro text capítol 3
                _uiManager.StoryStateUISwitcher(StoryState.Introduction); //Activa objecte en funció de StoryState
                break;
            case StoryState.MainStreet:
                // Activa info de la Card
                _uiManager.StoryStateUISwitcher(StoryState.MainStreet);
                break;
            case StoryState.RightSideStreet:
                //Activa info de la llibrería
                _uiManager.StoryStateUISwitcher(StoryState.RightSideStreet);
                break;
            case StoryState.LeftSideStreet:
                // Activa info de Puzzle II electricitat
                _uiManager.StoryStateUISwitcher(StoryState.LeftSideStreet);
                break;
            case StoryState.Alley:
                // Entrada al restaurant
                _uiManager.StoryStateUISwitcher(StoryState.Alley);
                break;
            case StoryState.ToBeContinued:
                // Info final Demo
                break;
        }

        // Lògica addicional per quan es canvia d'estat
    }
    
    void Awake()
    {
        _uiManager = GetComponent<UIManager>();
        _gameStateManager = GetComponent<GameStateManager>();
        _playerControl = FindObjectOfType<PlayerCameraSwitcher>();
        
        //_storyModeTimeline = GetComponent<PlayableDirector>(); //Funcionalitats Timeline (WIP)
    }

    // Mètode per entrar a GameState StoryMode
    public void EnterStoryMode()
    {
        _gameStateManager.SetState(GameState.StoryMode);
        DisablePlayerControls();
    }

    // Mètode per sortir de  GameState StoryMode i tornar a Exploració
    public void ExitStoryMode()
    {
        _gameStateManager.SetState(GameState.Navigation);
        EnablePlayerControls(); 
    }

    // Mètode per desactivar habilitat per nevegar de l'usuri
    private void DisablePlayerControls()
    {
        // La lògica per desactivar els controls del jugador va aquí
        _playerControl.enabled = false;
    }
    // Mètode per activar habilitat per nevegar de l'usuri
    private void EnablePlayerControls()
    {
        // La lògica per activar els controls del jugador va aquí
        _playerControl.enabled = true;
    }
}
