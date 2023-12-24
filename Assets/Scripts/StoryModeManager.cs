using UnityEngine;
using UnityEngine.Playables;

//Aquesta classe esta Work in Progress
public class StoryModeManager : MonoBehaviour
{
    private GameStateManager _gameStateManager; //Variable per controlar estats del joc
    private PlayerCameraSwitcher _playerControl; //Activa o desactiva capaciat de navegació

    void Awake()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();
        _playerControl = FindObjectOfType<PlayerCameraSwitcher>();
    }
    void Start()
    {

        // Comprova si el GameStateManager es troba en l'escena
        if (_gameStateManager == null)
        {
            Debug.LogError("No hi ha GameStateManage!!!r");
        }
        
    }
    
    // Mètode per entrar a GameState StoryMode
    public void EnterStoryMode()
    {
        _gameStateManager.SetState(GameState.StoryMode);
        //_storyModeTimeline.Play();
        DisablePlayerControls();
    }

    // Mètode per sortir de  GameState StoryMode i tornar a Exploració
    public void ExitStoryMode()
    {
        _gameStateManager.SetState(GameState.Exploration);
        EnablePlayerControls(); 
    }

    // Mètode per desactivar habilitat per nevegar de l'usuri
    private void DisablePlayerControls()
    {
        // La lògica per desactivar els controls del jugador va aquí
        _playerControl.enabled = false;
    }
    // Mètode per activar habilitat per nevegar de l'usuri
    private void EnablePlayerControls()
    {
        // La lògica per activar els controls del jugador va aquí
        _playerControl.enabled = true;
    }
}
