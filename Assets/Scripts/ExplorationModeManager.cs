using UnityEngine;

public class ExplorationModeManager : MonoBehaviour
{
    private StoryState _currentStoryState;
    private GameManager _gameStateManager; //Variable per controlar estats del joc
    private UIManager _uiManager;
    private bool _isUIActive;
    
    public ItemPickup[] items; //Variable Accés a item per a mètode Pickup

    void Start()
    {
        //Busquem i assignem els components a variables
        _isUIActive = false;
        _gameStateManager = GetComponent<GameManager>();
        _uiManager = GetComponent<UIManager>();
        items = FindObjectsOfType<ItemPickup>();
    }
    
    // Mètode per entrar a GameState ExplorationMode
    public  void ExplorationModeButton()
    {
        if (_gameStateManager.CurrentState != GameState.Exploration)
        {
            _uiManager.GameStateSwitcherUI(GameState.Exploration);
            Time.timeScale = 0f;
        }
        else if (_gameStateManager.CurrentState == GameState.Exploration)
        {
            _uiManager.GameStateSwitcherUI(GameState.Navigation);
            Time.timeScale = 1f;
        }
        else return;
    }
}
