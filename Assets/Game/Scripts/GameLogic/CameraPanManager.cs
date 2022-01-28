using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraPanManager : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook playerCam;
    [SerializeField] private CinemachineVirtualCamera wallCam;

    private void Start(){
        GameManager.Instance.OnPlayerFinished += SwitchPriority;
    }

    public void SwitchPriority(object sender, GameManager.OnPlayerFinishedEventArgs e){
        if(playerCam.Priority == 1){
            playerCam.Priority = 0;
            wallCam.Priority = 1;
        }
        else{
            playerCam.Priority = 1;
            wallCam.Priority = 0;
        }
    }
}
