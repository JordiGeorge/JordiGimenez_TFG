using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class MenuInventoryManager : MonoBehaviour
{
    //Variable de GameState per poder controlar els stats del joc 
    private GameStateManager _gameStateManager;
    
    [SerializeField] private TextMeshProUGUI textToChange; // Variable de tipus TextMeshProUGUI
    [SerializeField] private string newText; // Variable de tipus string per a canvi de text

    void Start()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();
        
        // Comprova si el GameStateManager es troba en l'escena
        if (_gameStateManager == null)
        {
            Debug.LogError("No hi ha GameStateManage!!!r");
        }
        
    }

    private void ChangeTheText()
    {
        // Canvia el text de l'element UI
        textToChange.text = newText;
    }
    
    public void EnterMenuInventory()
    {
        // Canvia a l'estat d'Inventari i pausa el temps
        _gameStateManager.SetState(GameState.Inventory);
        Time.timeScale = 0f;
    }

    public void LeaveMenuInventory()
    {
        // Canvia a l'estat d'Exploració i reprèn el temps
        _gameStateManager.SetState(GameState.Exploration);
        Time.timeScale = 1f;
    }
}


