using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class PlayerCameraSwitcher : MonoBehaviour
{
    private GameStateManager _gameStateManager; //Variable per controlar els GameStates del joc
    private StoryModeManager _storyModeManager; //Variable per controlar els StoryStates del joc

    public List<CinemachineVirtualCamera> cameras; //LListat de Càmeres virtuales
    private int _currentCameraIndex = 0;

    private bool _canSwitch = true; //Activa o desactiva moviment
    private const float SwitchCooldown = 5.0f; // variable de temps per la coroutine
    
    private void Awake()
    {
        //Busquem i assignem component GameStateManager i StoryModeManager
        _gameStateManager = FindObjectOfType<GameStateManager>();
        _storyModeManager = FindObjectOfType<StoryModeManager>();
    }

    void Start()
    {
        if (_gameStateManager == null)
        {
            this.enabled = false;
            Debug.LogError("No s'ha trobat GameStateManager!!!");
        }
        //Activem GameState Explortació (l'usuari pot navegar)
        _gameStateManager.SetState(GameState.Exploration);
        
        //Activem Progrés de la història
        _storyModeManager.SetStoryState(StoryState.Introduction);
        
        // La primera càmera es índex 0
        SwitchCamera(0);
    }

    void Update()
    {
        if (_canSwitch)
        {
            if (_currentCameraIndex == 0)
            {
                // Canvia a 1 amb S o Down Arrow quan l'índex és 0
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    SwitchCamera(1);
                }
            }
            else if (_currentCameraIndex == 1)
            {
                // Canvia a 0 amb W o la up Arrow quan l'índex és 1
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    SwitchCamera(0);
                }
                // Canvia a índex de càmera 2 amb D o Right Arrow
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    SwitchCamera(2);
                }
                // Salta a la càmera 3 amb A o Left Arrow
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    SwitchCamera(3);
                }
            }
            else if (_currentCameraIndex == 2)
            {
                // Tsalta a l'índex 1 amb S o Down Arrow
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    SwitchCamera(1);
                }
                // Salta a la càmera 3 amb A o Left Arrow
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    SwitchCamera(3);
                }
            }
            else if (_currentCameraIndex == 3)
            {
                // Va a l'índex de càmera 4 amb W o Up Arrow
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && _currentCameraIndex < cameras.Count - 1)
                {
                    SwitchCamera(4);
                }
                // Torna a l'índex 1 amb S o la Down Arrow
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    SwitchCamera(1);
                }
                // Canvia a la càmera 2 amb D o Right Arrow
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    SwitchCamera(2);
                }
            }
            else if (_currentCameraIndex == 4)
            {
                //storyModeManager.SetStoryState(StoryState.Alley);
                
                // Canvia a 3 amb S o Down Arrow quan l'índex és 4
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    SwitchCamera(3);
                }
            }
        }
    }
    
    //Coroutine de 5 Segons d'espera per acabar transicions abans de poder canviar de nou de càmera
    IEnumerator SwitchCameraCooldown()
    {
        _canSwitch = false;
        yield return new WaitForSeconds(SwitchCooldown);
        _canSwitch = true;
    }
    
    //Mètode que permet canviar Index de la Llista de Càmeres Virtuals
    private void SwitchCamera(int index)
    {
        StartCoroutine(SwitchCameraCooldown());
        foreach (CinemachineVirtualCamera cam in cameras)
        {
            cam.Priority = (cam == cameras[index]) ? 10 : 0;
        }

        // Seguiment de l'índex de la càmera actual
        Debug.Log("Canviat a l'índex de Càmera: " + index);

        _currentCameraIndex = index; // Actualitza l'índex de la càmera actual
        
        //Aprofitem funció de canvi de càmera per índex, per actualitzar l'estat de la història
        StoryState stroryStateByInt = (StoryState)index; //Accedim a valor d'Enum per Índex
        _storyModeManager.SetStoryState(stroryStateByInt); //Canviem progrés de la història en base a index de càmera (Posició de jugador)
    }
}
