using UnityEngine;

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
    private UIManager _uiManager;
    private bool _isUIActive;
    
    // Propietat de la classe pel control de la història actual
    public StoryState CurrentStoryState
    {
        get { return _currentStoryState; }
        set { SetStoryState(value); }
    }
    void Awake()
    {
        _gameStateManager = GetComponent<GameStateManager>();
        _uiManager = GetComponent<UIManager>();
        _isUIActive = false;
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
    
    //Usem el mateix botó per entrar/sortir a Mode Exploració
    public void ToggleUI()
    {
        if (!_isUIActive)
            EnterStoryMode();
        else if (_isUIActive)
            ExitStoryMode();
    }

    // Mètode per entrar a GameState StoryMode
    private void EnterStoryMode()
    {
        _gameStateManager.SetState(GameState.StoryMode);
        _isUIActive = true;
    }

    // Mètode per sortir de  GameState StoryMode i tornar a Exploració
    private void ExitStoryMode()
    {
        _gameStateManager.SetState(GameState.Navigation);
        _isUIActive = false;
    }
}
