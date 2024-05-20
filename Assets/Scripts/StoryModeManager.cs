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
    private GameManager _gameStateManager; //Variable per controlar estats del joc
    private UIManager _uiManager;
    
    // Propietat de la classe pel control de la història actual
    public StoryState CurrentStoryState
    {
        get { return _currentStoryState; }
        set { SetStoryState(value); }
    }
    void Awake()
    {
        _gameStateManager = GetComponent<GameManager>();
        _uiManager = GetComponent<UIManager>();
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

    // Mètode per entrar a GameState StoryMode
    public  void StoryModeButton()
    {
            if (_gameStateManager.CurrentState != GameState.StoryMode)
            {
                _uiManager.GameStateSwitcherUI(GameState.StoryMode);
                Time.timeScale = 0f;
            }
            else if (_gameStateManager.CurrentState == GameState.StoryMode)
            {
                _uiManager.GameStateSwitcherUI(GameState.Navigation);
                Time.timeScale = 1f;
            }
            else return;
    }
}
