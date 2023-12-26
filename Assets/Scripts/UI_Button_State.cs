using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_State : MonoBehaviour
{
    private Color disabledColor;
    private Color enabledColor;
    private Image imageColor;

    // OnEnable 
    void OnEnable()
    {
        imageColor = GetComponent<Image>();

        disabledColor = Color.gray;
        enabledColor = Color.cyan;
    }

    // Update is called once per frame
    public void EnabledButton()
    {
        imageColor.color = enabledColor;
    }

    public void DisabledButton()
    {
        imageColor.color = disabledColor;
    }
}
