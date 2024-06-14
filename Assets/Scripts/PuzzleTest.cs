using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTest : MonoBehaviour 
{
    private UIManager _uiManager;
    //private GameManager _gameStateManager;
    private TextMeshProUGUI _textToChange; // Variable de tipus TextMeshProUGUI
    
    //Tintem color del objecte de vermell quan el mouse esta a sobre (hover)
    private Color _mouseOverColor = Color.red;
    private Color _originalColor;

    // Variables pels components mesh and sprite renderer 
    private MeshRenderer _meshRenderer;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _uiManager = FindFirstObjectByType<UIManager>();
        //_gameStateManager = FindFirstObjectByType<GameManager>();
        if(_textToChange != null)
        _textToChange = _uiManager.explorationUI.GetComponentInChildren<TextMeshProUGUI>();
        
        _meshRenderer = GetComponent<MeshRenderer>();
        if (_meshRenderer != null)
        {
            _originalColor = _meshRenderer.material.color; //Assignem el color del material mesh renderer
        }
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer != null)
        {
            _originalColor = _spriteRenderer.color; //Assignem el color del sprite
        }
    }
        
    private void OnMouseDown()
    {
        EnterPuzzleScene();
    }

    private void OnMouseOver()
    {
        if (_meshRenderer != null)
            {
                _meshRenderer.material.color = _mouseOverColor;
            }
            else if (_spriteRenderer != null)
            {
                _spriteRenderer.color = _mouseOverColor;
            }
        
            _textToChange.text = gameObject.name;
        
    }

    private void OnMouseExit()
    {
            if (_meshRenderer != null)
            {
                _meshRenderer.material.color = _originalColor;
                _textToChange.text = null; //Reset de la UI d'exploracio
            }
            else if (_spriteRenderer != null)
            {
                _spriteRenderer.color = _originalColor;
                _textToChange.text = null;//Reset de la UI d'exploracio
            }
    }

    private void EnterPuzzleScene()
    {
        SceneManager.LoadScene(2);
    }
}
