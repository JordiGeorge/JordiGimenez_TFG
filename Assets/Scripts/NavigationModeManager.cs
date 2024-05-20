using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class NavigationModeManager : MonoBehaviour
{
    private GameManager _gameStateManager; //Variable per controlar els GameStates del joc
    private StoryModeManager _storyModeManager; //Variable per controlar els StoryStates del joc
    
    public List<CinemachineVirtualCamera> cameras; //LListat de Càmeres virtuales
    private int _currentCameraIndex = 0;

    [SerializeField] private bool canSwitch = true; //Activa o desactiva moviment
    private const float SwitchCooldown = 5.0f; // variable de temps per la coroutine
    
    //Navigation UI
    public GameObject cameraDownUI;
    public GameObject cameraUpUI;
    public GameObject cameraRightUI;
    public GameObject cameraLeftUI;

    private Image _navigationUI_up;
    private Image _navigationUI_down;
    private Image _navigationUI_right;
    private Image _navigationUI_left;
    
    private void Awake()
    {
        //Busquem i assignem component GameStateManager i StoryModeManager
        _gameStateManager = GetComponent<GameManager>();
        _storyModeManager = GetComponent<StoryModeManager>();
                
        _navigationUI_down = cameraDownUI.GetComponent<Image>();
        _navigationUI_up = cameraUpUI.GetComponent<Image>();
        _navigationUI_right = cameraRightUI.GetComponent<Image>();
        _navigationUI_left = cameraLeftUI.GetComponent<Image>();
    }

    void Start()
    {
        // La primera càmera es índex 0
        SwitchCamera(0);
    }

    void Update()
    {
        if (canSwitch && _gameStateManager.CurrentState == GameState.Navigation)
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
        canSwitch = false;
        yield return new WaitForSeconds(SwitchCooldown);
        canSwitch = true;
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
        
        //Canvi d'estat de navegació a UI
        if (_currentCameraIndex == 0)
        {            
            _navigationUI_down.color = Color.cyan;
            _navigationUI_up.color = Color.gray;
            _navigationUI_right.color = Color.gray;
            _navigationUI_left.color = Color.gray;
        }
        else if (_currentCameraIndex == 1)
        {
            //Canvi d'estat de navegació a UI
            _navigationUI_down.color = Color.gray;
            _navigationUI_up.color = Color.cyan;
            _navigationUI_right.color = Color.cyan;
            _navigationUI_left.color = Color.cyan;
        }
        else if (_currentCameraIndex == 2)
        {            
            _navigationUI_down.color = Color.cyan;
            _navigationUI_up.color = Color.gray;
            _navigationUI_right.color = Color.gray;
            _navigationUI_left.color = Color.cyan;
        }
        else if (_currentCameraIndex == 3)
        {
            //Canvi d'estat de navegació a UI
            _navigationUI_down.color = Color.cyan;
            _navigationUI_up.color = Color.cyan;
            _navigationUI_right.color = Color.cyan;
            _navigationUI_left.color = Color.gray;
        }
        else if (_currentCameraIndex == 4)
        {
            //Canvi d'estat de navegació a UI
            _navigationUI_down.color = Color.cyan;
            _navigationUI_up.color = Color.gray;
            _navigationUI_right.color = Color.gray;
            _navigationUI_left.color = Color.gray;
        }
    }
}
