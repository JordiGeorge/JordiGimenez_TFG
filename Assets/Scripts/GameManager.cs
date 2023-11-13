using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void LoadGame()
    {
        Debug.Log("Game Loaded");
        SceneManager.LoadScene(1);
    }
    
    // Start is called before the first frame update
    public void ExitGame()
    {
        Debug.Log("Game Exit");
        Application.Quit();
    }
}
