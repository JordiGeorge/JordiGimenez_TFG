using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class DevelopUI : MonoBehaviour
{
    //Variable de GameState per poder controlar els stats del joc 
    private GameStateManager _gameStateManager;
    private StoryModeManager _storyStateManager;
    
    public GameObject devGameStateUI;
    public GameObject devStoryStateUI;
    public GameObject devLocationUI;
    //public GameObject devChapterUI;
    
    private TextMeshProUGUI devStoryTMP; // Variable de tipus TextMeshProUGUI
    private string storyStateText; // Variable de tipus string per a canvi de text
    private TextMeshProUGUI devGameStateTMP; // Variable de tipus TextMeshProUGUI
    private string gameStateText; // Variable de tipus string per a canvi de text
    private TextMeshProUGUI devLocationTMP; // Variable de tipus TextMeshProUGUI
    private string locationText; // Variable de tipus string per a canvi de text

    void Start()
    {
        _gameStateManager = GetComponent<GameStateManager>();
        _storyStateManager = GetComponent<StoryModeManager>();

        devStoryTMP = devStoryStateUI.GetComponent<TextMeshProUGUI>();
        devStoryTMP.text = storyStateText;
        
        devGameStateTMP = devGameStateUI.GetComponent<TextMeshProUGUI>();
        devGameStateTMP.text = gameStateText;
        
        devLocationTMP = devLocationUI.GetComponent<TextMeshProUGUI>();
        devLocationTMP.text = locationText;
        
        // Comprova si el GameStateManager o StoryModeManageres troba en l'escena
        if (_gameStateManager == null || _storyStateManager == null)
        {
            Debug.LogError("No hi ha GameStateManage!!!r");
        }
    }
    
    public void InfoDevelopUI()
    {
        if (_gameStateManager == null) return;
        
        // Activa les diferents UI segons GameState
        switch (_gameStateManager.CurrentState)
        {
            case GameState.Exploration:
                
                gameStateText = "Mode Exploració";
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
