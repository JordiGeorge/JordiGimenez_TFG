using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class NavigationModeManager : MonoBehaviour
{
    private GameManager _gameStateManager; // Variable per controlar els GameStates del joc
    private StoryModeManager _storyModeManager; // Variable per controlar els StoryStates del joc

    public List<CinemachineVirtualCamera> cameras; // Llistat de Càmeres virtuals
    private int _currentCameraIndex = 0;

    [SerializeField] private bool canSwitch = true; // Activa o desactiva moviment
    private const float SwitchCooldown = 5.0f; // Variable de temps per la coroutine

    // UI de Navegació
    public GameObject cameraDownUI;
    public GameObject cameraUpUI;
    public GameObject cameraRightUI;
    public GameObject cameraLeftUI;
    public GameObject cameraHomeUI; // Nova càmera per la posició inicial

    private Image _navigationUI_up;
    private Image _navigationUI_down;
    private Image _navigationUI_right;
    private Image _navigationUI_left;
    private Image _navigationUI_home; // Nou component d'imatge per la posició inicial

    private Button _navigationButton_up;
    private Button _navigationButton_down;
    private Button _navigationButton_right;
    private Button _navigationButton_left;
    private Button _navigationButton_home; // Nou botó per la posició inicial

    private void Awake()
    {
        // Busquem i assignem component GameStateManager i StoryModeManager
        _gameStateManager = GetComponent<GameManager>();
        _storyModeManager = GetComponent<StoryModeManager>();

        // Assignació components Image
        _navigationUI_down = cameraDownUI.GetComponent<Image>();
        _navigationUI_up = cameraUpUI.GetComponent<Image>();
        _navigationUI_right = cameraRightUI.GetComponent<Image>();
        _navigationUI_left = cameraLeftUI.GetComponent<Image>();
        _navigationUI_home = cameraHomeUI.GetComponent<Image>(); // Assignar la nova imatge

        // Assignació components Button
        _navigationButton_down = cameraDownUI.GetComponent<Button>();
        _navigationButton_up = cameraUpUI.GetComponent<Button>();
        _navigationButton_right = cameraRightUI.GetComponent<Button>();
        _navigationButton_left = cameraLeftUI.GetComponent<Button>();
        _navigationButton_home = cameraHomeUI.GetComponent<Button>(); // Assignar el nou botó

        // Assignar mètodes als botons
        _navigationButton_down.onClick.AddListener(() =>
        {
            if (_currentCameraIndex == 4)
            {
                ChangeCamera(3); // Torna a la càmera 3 si actualment estem a la 4
            }
            else
            {
                ChangeCamera(_currentCameraIndex + 1); // Mou cap avall una càmera
            }
        });

        _navigationButton_up.onClick.AddListener(() =>
        {
            if (_currentCameraIndex == 3)
            {
                ChangeCamera(4); // Mou a la càmera 4 si actualment estem a la 3
            }
            else
            {
                ChangeCamera(_currentCameraIndex - 1); // Mou cap amunt una càmera
            }
        });

        _navigationButton_right.onClick.AddListener(() => ChangeCamera(_currentCameraIndex + 1)); // Mou a la dreta
        _navigationButton_left.onClick.AddListener(() => ChangeCamera(_currentCameraIndex - 1)); // Mou a l'esquerra
    }

    void Start()
    {
        SwitchCamera(0); // Inicialitza la càmera a la primera
    }

    void Update()
    {
        if (canSwitch && _gameStateManager.CurrentState == GameState.Navigation)
        {
            HandleCameraSwitching(); // Gestiona els canvis de càmera en funció de la entrada de teclat
        }
    }

    // Coroutine que gestiona el retard en canviar de càmera
    IEnumerator SwitchCameraCooldown()
    {
        canSwitch = false;
        yield return new WaitForSeconds(SwitchCooldown); // Espera el temps de SwitchCooldown
        canSwitch = true;
    }

    // Canvia a la càmera indicada pel índex
    private void SwitchCamera(int index)
    {
        StartCoroutine(SwitchCameraCooldown()); // Comença el retard de canvi de càmera

        foreach (CinemachineVirtualCamera cam in cameras)
        {
            cam.Priority = (cam == cameras[index]) ? 10 : 0; // Assigna la prioritat a la càmera seleccionada
        }

        _currentCameraIndex = index; // Actualitza l'índex de la càmera actual

        // Actualitza l'estat de la història basat en l'índex
        StoryState storyStateByInt = (StoryState)index;
        _storyModeManager.SetStoryState(storyStateByInt);

        UpdateNavigationComponents(); // Actualitza el HUD de navegació
    }

    // Canvia a una càmera específica en funció del índex objectiu
    public void ChangeCamera(int targetIndex)
    {
        if (canSwitch && targetIndex >= 0 && targetIndex < cameras.Count)
        {
            if (_currentCameraIndex == 3 && targetIndex == 0)
            {
                targetIndex = 4; // Canvia a la càmera 4 si estem a la 3 i volem anar a la 0
            }
            if (_currentCameraIndex == 4 && targetIndex == 1)
            {
                targetIndex = 3; // Canvia a la càmera 3 si estem a la 4 i volem anar a la 1
            }

            SwitchCamera(targetIndex); // Realitza el canvi de càmera
        }
    }

    // Gestiona els canvis de càmera en funció de la entrada de teclat
    private void HandleCameraSwitching()
    {
        if (_currentCameraIndex == 0)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                ChangeCamera(1); // Mou a la càmera 1 si estem a la càmera 0 i s'apreta S o la fletxa cap avall
            }
        }
        else if (_currentCameraIndex == 1)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                ChangeCamera(0); // Mou a la càmera 0 si estem a la càmera 1 i s'apreta W o la fletxa cap amunt
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                ChangeCamera(2); // Mou a la càmera 2 si estem a la càmera 1 i s'apreta D o la fletxa cap a la dreta
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                ChangeCamera(3); // Mou a la càmera 3 si estem a la càmera 1 i s'apreta A o la fletxa cap a l'esquerra
            }
        }
        else if (_currentCameraIndex == 2)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                ChangeCamera(1); // Mou a la càmera 1 si estem a la càmera 2 i s'apreta S o la fletxa cap avall
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                ChangeCamera(3); // Mou a la càmera 3 si estem a la càmera 2 i s'apreta A o la fletxa cap a l'esquerra
            }
        }
        else if (_currentCameraIndex == 3)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                ChangeCamera(4); // Mou a la càmera 4 si estem a la càmera 3 i s'apreta W o la fletxa cap amunt
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                ChangeCamera(1); // Mou a la càmera 1 si estem a la càmera 3 i s'apreta S o la fletxa cap avall
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                ChangeCamera(2); // Mou a la càmera 2 si estem a la càmera 3 i s'apreta D o la fletxa cap a la dreta
            }
        }
        else if (_currentCameraIndex == 4)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                ChangeCamera(3); // Mou a la càmera 3 si estem a la càmera 4 i s'apreta S o la fletxa cap avall
            }
        }
    }

    // Actualitza els components de navegació en funció de la càmera actual
    private void UpdateNavigationComponents()
    {
        // Reseteja els estats de la UI
        _navigationUI_up.color = Color.gray;
        _navigationUI_down.color = Color.gray;
        _navigationUI_right.color = Color.gray;
        _navigationUI_left.color = Color.gray;
        _navigationUI_home.color = Color.gray;
        _navigationButton_up.interactable = false;
        _navigationButton_down.interactable = false;
        _navigationButton_right.interactable = false;
        _navigationButton_left.interactable = false;
        
        _navigationButton_home.interactable = true; // Botó sempre actiu

        // Actualitza la UI i els botons basant-se en la càmera actual
        switch (_currentCameraIndex)
        {
            case 0:
                _navigationUI_down.color = Color.cyan; // Activa la opció cap avall
                _navigationButton_down.interactable = true;
                break;
            case 1:
                _navigationUI_up.color = Color.cyan; // Activa la opció cap amunt
                _navigationUI_right.color = Color.cyan; // Activa la opció cap a la dreta
                _navigationUI_left.color = Color.cyan; // Activa la opció cap a l'esquerra
                _navigationButton_up.interactable = true;
                _navigationButton_right.interactable = true;
                _navigationButton_left.interactable = true;
                break;
            case 2:
                _navigationUI_down.color = Color.cyan; // Activa la opció cap avall
                _navigationUI_left.color = Color.cyan; // Activa la opció cap a l'esquerra
                _navigationButton_down.interactable = true;
                _navigationButton_left.interactable = true;
                break;
            case 3:
                _navigationUI_down.color = Color.cyan; // Activa la opció cap avall
                _navigationUI_up.color = Color.cyan; // Activa la opció cap amunt
                _navigationUI_right.color = Color.cyan; // Activa la opció cap a la dreta
                _navigationButton_down.interactable = true;
                _navigationButton_up.interactable = true;
                _navigationButton_right.interactable = true;
                break;
            case 4:
                _navigationUI_down.color = Color.cyan; // Activa la opció cap avall
                _navigationButton_down.interactable = true;
                break;
            default:
                _navigationUI_home.color = Color.cyan; // Activa la opció de tornar a la posició inicial
                _navigationButton_home.interactable = true;
                break;
        }
    }
}


