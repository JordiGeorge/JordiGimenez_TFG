using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerCameraSwitcher : MonoBehaviour
{
    public List<CinemachineVirtualCamera> cameras;
    private int currentCameraIndex = 0;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.1f) // Derecha o joystick del gamepad hacia la derecha
        {
            SwitchToNextCamera();
        }
        else if (horizontalInput < -0.1f) // Izquierda o joystick del gamepad hacia la izquierda
        {
            SwitchToPreviousCamera();
        }
    }

    private void SwitchToNextCamera()
    {
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Count;
        SwitchCamera(currentCameraIndex);
    }

    private void SwitchToPreviousCamera()
    {
        if (currentCameraIndex == 0)
        {
            currentCameraIndex = cameras.Count - 1;
        }
        else
        {
            currentCameraIndex--;
        }
        SwitchCamera(currentCameraIndex);
    }

    private void SwitchCamera(int index)
    {
        foreach (CinemachineVirtualCamera cam in cameras)
        {
            cam.Priority = (cam == cameras[index]) ? 10 : 0;
        }
    }
}