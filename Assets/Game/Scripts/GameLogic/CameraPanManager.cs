using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPanManager : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook playerCam;
    [SerializeField] private CinemachineVirtualCamera wallCam;

    public void SwitchPriority(){
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
