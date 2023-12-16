using UnityEngine;
using UnityEngine.UI; // For standard UI
using TMPro; // For TextMeshPro

public class GameMenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    
    public TextMeshProUGUI textToChange; // Use 'public Text textToChange;' for standard UI text
    public string newText;

    public void ChangeTheText()
    {
        textToChange.text = newText;
    }
    
    public void ToggleMenu()
    {
        bool isActive = menuCanvas.activeSelf;

        // Toggle the menu's active state
        menuCanvas.SetActive(!isActive);

        // Pause or resume time based on the menu's state
        if (isActive)
        {
            // Resume time
            Time.timeScale = 1f;
        }
        else
        {
            // Pause time
            Time.timeScale = 0f;
        }
    }
}

