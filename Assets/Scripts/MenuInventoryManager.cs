using UnityEngine;

public enum MenuIndex
{
    Profile,
    Inventory,
    Mission,
    Log
}

public class MenuInventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] infoMenu;

    private MenuIndex _menuIndex;

    // Propietat per accedir a l'estat actual
    public MenuIndex CurrentIndex
    {
        get { return _menuIndex; }
        set { SetState(value); }
    }
    
    public void SetState(MenuIndex newIndex)
    {
        _menuIndex = newIndex;
        Debug.Log("Menu Index: " + _menuIndex); // Seguiment dels estats del joc
    }
    
    //Variable de GameState per poder controlar els stats del joc 
    private GameManager _gameStateManager;
    private UIManager _uiManager;

    void Start()
    {
        _gameStateManager = GetComponent<GameManager>();
        _uiManager = GetComponent<UIManager>();
        SetState(MenuIndex.Profile);
        
        // Comprova si el GameStateManager es troba en l'escena
        if (_gameStateManager == null)
        {
            Debug.LogError("No hi ha GameStateManage!!!r");
        }
        
        // Comprova si InfoMenu està inicialitzat correctament
        if (infoMenu == null || infoMenu.Length == 0)
        {
            Debug.LogError("InfoMenu no està inicialitzat o és buit");
        }
    }
    
    public void InfoMenuPanel(int index)
    {
        /*// Comprova si l'índex està fora del rang
        if (index < 0 || index >= infoMenu.Length)
        {
            Debug.LogError("Índex fora de rang");
            return;
        }*/
        
        SetState((MenuIndex)index);

        switch (CurrentIndex)
        {
            case MenuIndex.Profile:
                // Lògica per al primer GameObject a InfoMenu
                infoMenu[0].SetActive(true);
                infoMenu[1].SetActive(false);
                infoMenu[2].SetActive(false);
                break;
            case MenuIndex.Inventory:
                // Lògica per al segon GameObject
                infoMenu[0].SetActive(false);
                infoMenu[1].SetActive(true);
                infoMenu[2].SetActive(false);
                break;
            case MenuIndex.Mission:
                // Lògica per al tercer GameObject
                infoMenu[0].SetActive(false);
                infoMenu[1].SetActive(false);
                infoMenu[2].SetActive(true);
                break;
            default:
                Debug.LogError("Índex invàlid");
                break;
        }
        
    }
    
    // Mètode per entrar a GameState StoryMode
    public void MenuInventoryButton()
    {
        if (_gameStateManager.CurrentState != GameState.Inventory)
        {
            _uiManager.GameStateSwitcherUI(GameState.Inventory);
            Time.timeScale = 0f;
        }
        else if (_gameStateManager.CurrentState == GameState.Inventory)
        {
            _uiManager.GameStateSwitcherUI(GameState.Navigation);
            Time.timeScale = 1f;
        }
        else return;
    }
}


