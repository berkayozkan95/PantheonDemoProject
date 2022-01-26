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
        if(other.gameObject.GetComponent<PlayerController>() != null){
            Debug.Log("You've Finished");
            camManager.SwitchPriority();
            other.gameObject.GetComponent<PlayerController>().StartCoroutine("Stop");    
            obstacles.gameObject.SetActive(false);
            brush.IsActive = true;
        }
    }

}
