using UnityEngine;
using UnityEngine.UI;
using TMPro; // Importa el paquet TextMeshPro
using System.Collections;

public class SequentialStoryMode : MonoBehaviour
{
    // Referències als objectes de TextMeshPro i al botó
    public TextMeshProUGUI text1; // TextMeshPro per al primer text
    public TextMeshProUGUI text2; // TextMeshPro per al segon text
    public TextMeshProUGUI text3; // TextMeshPro per al segon text
    public Button button; // Botó

    void Start()
    {
        // Textos i botó desactivats a l'inici
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        button.gameObject.SetActive(false);

        // Inicia la corutina per mostrar els textos i activar el botó
        StartCoroutine(ShowTextsAndActivateButton());
    }

    private IEnumerator ShowTextsAndActivateButton()
    {
        // Mostra el primer text
        text1.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f); // Espera 3 segons

        // Mostra el segon text
        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f); // Espera altres 3 segons
        
        // Mostra el tercer text
        text3.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f); // Espera altres 3 segons

        // Activa el botó
        button.gameObject.SetActive(true);
        button.interactable = true; // Fa que el botó sigui interactiu
    }
}


