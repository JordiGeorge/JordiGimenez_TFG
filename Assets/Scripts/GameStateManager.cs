using UnityEngine;

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
    private GameState currentState;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private StoryModeManager storyManager;
    [SerializeField]
    private DevelopUIManager developUI;

    // Propietat per accedir a l'estat actual
    public GameState CurrentState
    {
        get { return currentState; }
        set { SetState(value); }
    }
    
    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
        storyManager = GetComponent<StoryModeManager>();
        developUI = GetComponent<DevelopUIManager>();
    }

    void Start()
    {
        SetState(GameState.StoryMode);
        storyManager.SetStoryState(StoryState.Introduction);
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("GameState: " + currentState); // Seguiment dels estats del joc
    }
    
    // Actualització d'estats
    void Update()
    {
        developUI.InfoDevelopUI();
        uiManager.GameStateSwitcherUI();

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





