using UnityEngine;
using UnityEngine. UIElements;

public class Button_Screen : MonoBehaviour
{
    private VisualElement box;
    private Button myButton;

    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;
        box = root.Q("Box");
        myButton = root.Q<Button> ("myButton");
        myButton.clicked += OnButtonClicked;
    }
    void OnButtonClicked()
    {
        int randomWidth = Random. Range (50, 300);
        box.style.width = randomWidth;
    }
}
