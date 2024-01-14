using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class MenuInventoryManager : MonoBehaviour
{

    public GameObject[] infoMenu;
    
    //Variable de GameState per poder controlar els stats del joc 
    private GameStateManager _gameStateManager;
    
    private TextMeshProUGUI textToChange; // Variable de tipus TextMeshProUGUI
    private string newText; // Variable de tipus string per a canvi de text

    void Start()
    {
        _gameStateManager = GetComponent<GameStateManager>();
        
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

    
    public void InfoMenu(int index)
    {
        // Comprova si l'índex està fora del rang
        if (index < 0 || index >= infoMenu.Length)
        {
            Debug.LogError("Índex fora de rang");
            return;
        }

        switch (index)
        {
            case 0:
                // Lògica per al primer GameObject a InfoMenu
                // Exemple: Activa el primer menú i desactiva els altres
                infoMenu[0].SetActive(true);
                infoMenu[1].SetActive(false);
                infoMenu[2].SetActive(false);
                break;
            case 1:
                // Lògica per al segon GameObject
                infoMenu[0].SetActive(false);
                infoMenu[1].SetActive(true);
                infoMenu[2].SetActive(false);
                break;
            case 2:
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
    
    public void EnterMenuInventory()
    {
        // Canvia a l'estat d'Inventari i pausa el temps
        _gameStateManager.SetState(GameState.Inventory);
        InfoMenu(0);
        Time.timeScale = 0f;
    }

    public void LeaveMenuInventory()
    {
        // Canvia a l'estat d'Exploració i reprèn el temps
        _gameStateManager.SetState(GameState.Navigation);
        Time.timeScale = 1f;
    }
}


