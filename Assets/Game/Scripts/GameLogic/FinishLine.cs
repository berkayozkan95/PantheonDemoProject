using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    
    [SerializeField] GameObject obstacles;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerControllerBase>() != null){
            other.gameObject.GetComponent<PlayerControllerBase>().Stop();      
            other.GetComponent<PlayerControllerBase>().HasFinished = true;     
            if(other.CompareTag("Player")){ 
                    other.gameObject.GetComponent<InputManager>().enabled = false;
                    obstacles.gameObject.SetActive(false);  //I turn the obstacles off as they were blocking the camera while painting.
                    GameManager.Instance.PlayerFinished();
                }          
        }
    }
}
