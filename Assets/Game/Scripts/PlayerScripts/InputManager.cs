using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private float sweepPosX;
    private float deltaMoveX;
    public float DeltaMoveX => deltaMoveX;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            sweepPosX = Input.mousePosition.x;
        }
        else if(Input.GetMouseButton(0)){
            deltaMoveX = Input.mousePosition.x - sweepPosX;
            sweepPosX = Input.mousePosition.x;
        }
        else if(Input.GetMouseButtonUp(0)){
            deltaMoveX = 0f; 
        }
    }
}
