using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<PlayerControllerBase>()){
            other.gameObject.GetComponent<PlayerControllerBase>().BackToStart();
        }
    }
}