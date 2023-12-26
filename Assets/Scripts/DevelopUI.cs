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
    
    //Seguiment opcions càmeres disponibles en UI
    public GameObject cameraDownUI;
    public GameObject cameraUpUI;
    public GameObject cameraRightUI;
    public GameObject cameraLeftUI;
    
    private UI_Button_State buttonStateDown;
    private UI_Button_State buttonStateUp;
    private UI_Button_State buttonStateRight;
    private UI_Button_State buttonStateLeft;
    
    void Start()
    {
        // Comprova si el GameStateManager o StoryModeManageres troba en l'escena
        if (_gameStateManager == null || _storyStateManager == null)
        {
            Debug.LogError("No hi ha GameStateManager o StoryMode Manager!!!");
        }
        _gameStateManager = GetComponent<GameStateManager>();
        _storyStateManager = GetComponent<StoryModeManager>();

        devStoryTMP = devStoryStateUI.GetComponent<TextMeshProUGUI>();
        devStoryTMP.text = storyStateText;
        
        devGameStateTMP = devGameStateUI.GetComponent<TextMeshProUGUI>();
        devGameStateTMP.text = gameStateText;
        
        devLocationTMP = devLocationUI.GetComponent<TextMeshProUGUI>();
        devLocationTMP.text = locationText;
        
        buttonStateDown = cameraDownUI.GetComponent<UI_Button_State>();
        buttonStateUp = cameraUpUI.GetComponent<UI_Button_State>();
        buttonStateRight = cameraRightUI.GetComponent<UI_Button_State>();
        buttonStateLeft = cameraLeftUI.GetComponent<UI_Button_State>();
        
        buttonStateDown.EnabledButton();
        buttonStateUp.DisabledButton();
        buttonStateRight.DisabledButton();
        buttonStateLeft.DisabledButton();
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
                        buttonStateDown.EnabledButton();
                        buttonStateUp.DisabledButton();
                        buttonStateRight.DisabledButton();
                        buttonStateLeft.DisabledButton();
                        break;
                    case StoryState.MainStreet:
                        storyStateText = "La targeta de visita" ;
                        devStoryTMP.text = storyStateText;
                        locationText = "EXT.NIT: Carrer Principal(1)";
                        devLocationTMP.text = locationText;
                        buttonStateDown.DisabledButton();
                        buttonStateUp.EnabledButton();
                        buttonStateRight.EnabledButton();
                        buttonStateLeft.EnabledButton();
                        break;
                    case StoryState.RightSideStreet:
                        storyStateText = "La Llibrería";
                        devStoryTMP.text = storyStateText;
                        locationText = "EXT.NIT: Carrer Principal(2)";
                        devLocationTMP.text = locationText;
                        buttonStateDown.EnabledButton();
                        buttonStateUp.DisabledButton();
                        buttonStateRight.DisabledButton();
                        buttonStateLeft.EnabledButton();
                        break;
                    case StoryState.LeftSideStreet:
                        storyStateText = "Entrada al carreró fosc.";
                        devStoryTMP.text = storyStateText;
                        locationText = "EXT.NIT: Carrer Principal(3).";
                        devLocationTMP.text = locationText;
                        buttonStateDown.EnabledButton();
                        buttonStateUp.EnabledButton();
                        buttonStateRight.EnabledButton();
                        buttonStateLeft.DisabledButton();
                        break;
                    case StoryState.Alley:
                        storyStateText = "Porta misteriosa";
                        devStoryTMP.text = storyStateText;
                        locationText = "EXT.NIT: Carreró.";
                        devLocationTMP.text = locationText;
                        buttonStateDown.EnabledButton();
                        buttonStateUp.DisabledButton();
                        buttonStateRight.DisabledButton();
                        buttonStateLeft.DisabledButton();
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
