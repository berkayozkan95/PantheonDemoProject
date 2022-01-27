using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private CameraPanManager camManager;
    [SerializeField] GameObject obstacles;
    [SerializeField] Paintable brush;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerControllerBase>() != null){
            other.gameObject.GetComponent<PlayerControllerBase>().Stop();           
            if(other.CompareTag("Player")){ 
                other.gameObject.GetComponent<InputManager>().enabled = false; 
                camManager.SwitchPriority();
                obstacles.gameObject.SetActive(false);
                brush.IsActive = true;;
                }
             
            
        }
    }

}
