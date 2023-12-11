using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam01;
    [SerializeField] CinemachineVirtualCamera cam02;
    [SerializeField] CinemachineVirtualCamera cam03;
    [SerializeField] CinemachineVirtualCamera cam04;
    [SerializeField] CinemachineVirtualCamera cam05;

    private void OnEnable()
    {
        CameraSwitcher.Register(cam01);
        CameraSwitcher.Register(cam02);
        CameraSwitcher.Register(cam03);
        CameraSwitcher.Register(cam04);
        CameraSwitcher.Register(cam05);
        CameraSwitcher.SwitchCamera(cam01);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(cam01);
        CameraSwitcher.Unregister(cam02);
        CameraSwitcher.Unregister(cam03);
        CameraSwitcher.Unregister(cam04);
        CameraSwitcher.Unregister(cam05);
    }

    public void ChangeCameraForward()
    {
        //Switch Camera
        if (CameraSwitcher.IsActiveCamera(cam01))
        {
            CameraSwitcher.SwitchCamera(cam02);
        }
        else if (CameraSwitcher.IsActiveCamera(cam02))
        {
            CameraSwitcher.SwitchCamera(cam03);
        }
        else if (CameraSwitcher.IsActiveCamera(cam03))
        {
            CameraSwitcher.SwitchCamera(cam04);
        }
        else if (CameraSwitcher.IsActiveCamera(cam04))
        {
            CameraSwitcher.SwitchCamera(cam05);
        }
    }

    public void ChangeCameraBackward()
    {
       
        //Switch Camera
        if (CameraSwitcher.IsActiveCamera(cam05))
        {
            CameraSwitcher.SwitchCamera(cam04);
        }
        else if (CameraSwitcher.IsActiveCamera(cam04))
        {
            CameraSwitcher.SwitchCamera(cam03);
        }
        else if (CameraSwitcher.IsActiveCamera(cam03))
        {
            CameraSwitcher.SwitchCamera(cam02);
        }
        else if (CameraSwitcher.IsActiveCamera(cam02))
        {
            CameraSwitcher.SwitchCamera(cam01);
        }
    }
}
