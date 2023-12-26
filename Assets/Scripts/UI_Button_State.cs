using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_State : MonoBehaviour
{
    private Color disabledColor;
    private Color enabledColor;
    private Image imageColor;
    private Color buttonColor;
    
    // Start is called before the first frame update
    void Start()
    {
        imageColor = this.GetComponent<Image>();
        buttonColor= this.GetComponent<Button>().colors.normalColor;
        
        disabledColor = new Color(255, 255, 255, 20);
        enabledColor = new Color(255,150,15,255);
        
        DisabledButton();
    }

    // Update is called once per frame
    public void EnabledButton()
    {
        imageColor.color = enabledColor;
        //buttonColor = enabledColor;
    }

    public void DisabledButton()
    {
        imageColor.color = disabledColor;
        //buttonColor = disabledColor;
    }
}
