using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            Debug.Log("You've Finished");
            other.gameObject.GetComponent<PlayerController>().StartCoroutine("Stop");
        }
    }

}
