using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public enum StoryState
{
    Introduction,
    MainStreet,
    RightSideStreet,
    LeftSideStreet,
    Alley,
    ToBeContinued
}

//Aquesta classe esta Work in Progress
public class StoryModeManager : MonoBehaviour
{
    private StoryState _currentStoryState;
    
    // Propietat per accedir a l'estat actual
    public StoryState CurrentStoryState
    {
        get { return _currentStoryState; }
        set { SetStoryState(value); }
    }
    
    // Canvi dels estats del progrés d ela història
    public void SetStoryState(StoryState newState)
    {
        _currentStoryState = newState;
        Debug.Log("StoryState: " + _currentStoryState); // Seguiment del progrés de la història

        // Sortida per a l'estat actual
        switch (_currentStoryState)
        {
            case StoryState.Introduction:
                // Activa Intro text capítol 3
                break;
            case StoryState.MainStreet:
                // Activa info de la Card

                break;
            case StoryState.RightSideStreet:
                // // Activa info de la llibrería
                break;
            case StoryState.LeftSideStreet:
                // Activa info de Puzzle II electricitat
                break;
            case StoryState.Alley:
                // Entrada al restaurant
                break;
            case StoryState.ToBeContinued:
                // Info final Demo
                break;
        }

        // Lògica addicional per quan es canvia d'estat
    }

    private GameStateManager _gameStateManager; //Variable per controlar estats del joc
    private PlayerCameraSwitcher _playerControl; //Activa o desactiva capaciat de navegació
    public PlayableDirector _storyModeTimeline;
    [SerializeField] private UIManager _uiManager;
    public TimelineAsset timelineAsset;

    void Awake()
    {
        _uiManager = GetComponent<UIManager>();
        _gameStateManager = FindObjectOfType<GameStateManager>();
        _playerControl = FindObjectOfType<PlayerCameraSwitcher>();
        //_storyModeTimeline = GetComponent<PlayableDirector>();
    }
    void Start()
    {
        if (_storyModeTimeline == null)
        {
            _storyModeTimeline = GetComponent<PlayableDirector>();
        }
        // Comprova si el GameStateManager es troba en l'escena
        if (_gameStateManager == null)
        {
            Debug.LogError("No hi ha GameStateManage!!!r");
        }
        
        timelineAsset = (TimelineAsset)_storyModeTimeline.playableAsset;
        
    }
    
    // Mètode per entrar a GameState StoryMode
    public void EnterStoryMode()
    {
        _gameStateManager.SetState(GameState.StoryMode);
        //_storyModeTimeline.Play();
        DisablePlayerControls();
    }

    // Mètode per sortir de  GameState StoryMode i tornar a Exploració
    public void ExitStoryMode()
    {
        _gameStateManager.SetState(GameState.Exploration);
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
