using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraSwitcher : MonoBehaviour
{
    public List<CinemachineVirtualCamera> cameras;
    private int currentCameraIndex = 0;

    private bool canSwitch = true;
    private float switchCooldown = 5.0f; // Temps de refredament en segons

    void Start()
    {
        // Assegura't que la primera càmera (índex 0) sigui l'activa en començar
        SwitchCamera(0);
    }

    void Update()
    {
        if (canSwitch)
        {
            if (currentCameraIndex == 0)
            {
                // Canvia a 1 amb S o la fletxa avall quan l'índex és 0
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    SwitchCamera(1);
                }
            }
            else if (currentCameraIndex == 1)
            {
                // Canvia a 0 amb W o la fletxa amunt quan l'índex és 1
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    SwitchCamera(0);
                }
                // Canvia a la següent càmera amb D o fletxa dreta
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    SwitchCamera(2);
                }
                // Salta directament a la càmera 3 amb A o fletxa esquerra
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    SwitchCamera(3);
                }
            }
            else if (currentCameraIndex == 2)
            {
                // Torna a l'índex 1 amb S o la fletxa avall
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    SwitchCamera(1);
                }
                // Salta directament a la càmera 3 amb A o fletxa esquerra
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    SwitchCamera(3);
                }
            }
            else if (currentCameraIndex == 3)
            {
                // Va a l'índex de càmera 4 (si existeix) amb W o fletxa amunt
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && currentCameraIndex < cameras.Count - 1)
                {
                    SwitchCamera(4);
                }
                // Torna a l'índex 1 amb S o la fletxa avall
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    SwitchCamera(1);
                }
                // Canvia a la càmera 2 amb D o fletxa dreta
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    SwitchCamera(2);
                }
            }
            else if (currentCameraIndex == 4)
            {
                // Canvia a 3 amb S o la fletxa avall quan l'índex és 4
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    SwitchCamera(3);
                }
            }
        }
    }

    IEnumerator SwitchCameraCooldown()
    {
        canSwitch = false;
        yield return new WaitForSeconds(switchCooldown);
        canSwitch = true;
    }

    private void SwitchCamera(int index)
    {
        StartCoroutine(SwitchCameraCooldown());
        foreach (CinemachineVirtualCamera cam in cameras)
        {
            cam.Priority = (cam == cameras[index]) ? 10 : 0;
        }

        // Registra en el log l'índex de la càmera actual
        Debug.Log("Canviat a l'índex de Càmera: " + index);

        currentCameraIndex = index; // Actualitza l'índex de la càmera actual
    }
}
