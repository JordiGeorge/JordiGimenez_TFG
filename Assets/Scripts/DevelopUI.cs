using UnityEngine;
using TMPro;

public class DevelopUI : MonoBehaviour
{
    //Variable de GameState per poder controlar els stats del joc 
    private GameStateManager _gameStateManager;
    private StoryModeManager _storyStateManager;
    
    public GameObject devGameStateUI;
    public GameObject devStoryStateUI;
    public GameObject devLocationUI;
    
    private TextMeshProUGUI devStoryTMP; // Variable de tipus TextMeshProUGUI
    private string storyStateText; // Variable de tipus string per a canvi de text
    private TextMeshProUGUI devGameStateTMP; // Variable de tipus TextMeshProUGUI
    private string gameStateText; // Variable de tipus string per a canvi de text
    private TextMeshProUGUI devLocationTMP; // Variable de tipus TextMeshProUGUI
    private string locationText; // Variable de tipus string per a canvi de text
    
    
    private void Awake()
    {
        _gameStateManager = GetComponent<GameStateManager>();
        _storyStateManager = GetComponent<StoryModeManager>();
    }

    void Start()
    {
        devStoryTMP = devStoryStateUI.GetComponent<TextMeshProUGUI>();
        devStoryTMP.text = storyStateText;
        
        devGameStateTMP = devGameStateUI.GetComponent<TextMeshProUGUI>();
        devGameStateTMP.text = gameStateText;
        
        devLocationTMP = devLocationUI.GetComponent<TextMeshProUGUI>();
        devLocationTMP.text = locationText;
    }
    
    public void InfoDevelopUI()
    {
        if (_gameStateManager == null) return;
        
        // Activa les diferents UI segons GameState
        switch (_gameStateManager.CurrentState)
        {
            case GameState.Navigation:
                
                gameStateText = "Mode Navegació";
                devGameStateTMP.text = gameStateText;
                
                // Activa les diferents UI segons GameState
                switch (_storyStateManager.CurrentStoryState)
                {
                    case StoryState.Introduction:
                        storyStateText = "Introducció";
                        devStoryTMP.text = storyStateText;
                        locationText = "EXT.NIT: Els Terrats";
                        devLocationTMP.text = locationText;
                        break;
                    case StoryState.MainStreet:
                        storyStateText = "La targeta de visita" ;
                        devStoryTMP.text = storyStateText;
                        locationText = "EXT.NIT: Carrer Principal(1)";
                        devLocationTMP.text = locationText;
                        break;
                    case StoryState.RightSideStreet:
                        storyStateText = "La Llibrería";
                        devStoryTMP.text = storyStateText;
                        locationText = "EXT.NIT: Carrer Principal(2)";
                        devLocationTMP.text = locationText;
                        break;
                    case StoryState.LeftSideStreet:
                        storyStateText = "Entrada al carreró fosc.";
                        devStoryTMP.text = storyStateText;
                        locationText = "EXT.NIT: Carrer Principal(3).";
                        devLocationTMP.text = locationText;
                        break;
                    case StoryState.Alley:
                        storyStateText = "Porta misteriosa";
                        devStoryTMP.text = storyStateText;
                        locationText = "EXT.NIT: Carreró.";
                        devLocationTMP.text = locationText;
                        break;
                    case StoryState.ToBeContinued:
                        storyStateText = "Continuará al  Capítol 4. " + "\"Por a la foscor\"" ;
                        devStoryTMP.text = storyStateText;
                        break;
                }
                break;
            case GameState.Exploration:
                gameStateText = "Mode Exploració";
                devGameStateTMP.text = gameStateText;
                break;
            case GameState.Inventory:
                gameStateText = "Mode Menu/Inventari";
                devGameStateTMP.text = gameStateText;
                break;
            case GameState.Puzzle:
                gameStateText = "Mode Trencaclosques";
                devGameStateTMP.text = gameStateText;
                break;
            case GameState.StoryMode:
                gameStateText = "Mode Història";
                devGameStateTMP.text = gameStateText;
                break;
        }
    }
}
