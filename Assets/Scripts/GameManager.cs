using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Player currentCamera;

    public GameManager()
    {
        //Initialize();
    }

    public void Start()
    {
        // Carrega els recursos necessaris
        // Inicialitza els objectius del cap�tol
        // Inicialitza els controls del jugador
        // Inicialitza l'entorn del cap�tol
        // Inicialitza els personatges del cap�tol

        //SceneManager.LoadScene(1);
   
       
    }

    public void Update()
    {
        // Actualitza els objectius del cap�tol
        // Actualitza els controls del jugador
        // Actualitza l'entorn del cap�tol
        // Actualitza els personatges del cap�tol


        if (Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentCamera.ChangeCameraForward();
        }

    }

    // Start is called before the first frame update
    public void LoadStartMenu()
    {
        Debug.Log("Game Loaded");
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        Debug.Log("Game Loaded");
        //SceneManager.LoadScene(1);
    }

    public void LoadInGameMenu()
    {
        Debug.Log("In Game Menu");
        //SceneManager.LoadScene(1);
    }

    // Start is called before the first frame update
    public void ExitGame()
    {
        Debug.Log("Game Exit");
        Application.Quit();
    }
}


