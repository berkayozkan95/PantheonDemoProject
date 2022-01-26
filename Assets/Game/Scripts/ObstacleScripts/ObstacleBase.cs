using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            Debug.Log("Collided");
            other.gameObject.GetComponent<PlayerController>().BackToStart();
        }
    }
}