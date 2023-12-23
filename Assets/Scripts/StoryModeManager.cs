using UnityEngine;

//Aquesta classe esta Work in Progress
public class StoryModeManager : MonoBehaviour
{
    private GameStateManager gameStateManager; //Variable per controlar estats del joc
    public PlayerCameraSwitcher playerControl; //Activa o desactiva capaciat de navegació
    
    void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        
        // Comprova si el GameStateManager es troba en l'escena
        if (gameStateManager == null)
        {
            Debug.LogError("No hi ha GameStateManage!!!r");
        }
        
    }
    
    // Mètode per entrar a GameState StoryMode
    public void EnterStoryMode()
    {
        gameStateManager.SetState(GameState.StoryMode);
        DisablePlayerControls();
    }

    // Mètode per sortir de  GameState StoryMode i tornar a Exploració
    public void ExitStoryMode()
    {
        gameStateManager.SetState(GameState.Exploration);
        EnablePlayerControls(); 
    }

    // Mètode per desactivar habilitat per nevegar de l'usuri
    private void DisablePlayerControls()
    {
        // La lògica per desactivar els controls del jugador va aquí
        playerControl.enabled = false;
    }
    // Mètode per activar habilitat per nevegar de l'usuri
    private void EnablePlayerControls()
    {
        // La lògica per activar els controls del jugador va aquí
        playerControl.enabled = true;
    }
}
