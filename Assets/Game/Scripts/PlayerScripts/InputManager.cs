using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private float sweepPosX;
    private float deltaMoveX;

    public float DeltaMoveX => deltaMoveX;

    private Touch touch;

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

       if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                sweepPosX = Input.mousePosition.x;
            if (touch.phase == TouchPhase.Moved){
                deltaMoveX = Input.mousePosition.x - sweepPosX;
                sweepPosX = Input.mousePosition.x;
            }            
            if (touch.phase == TouchPhase.Ended)
                deltaMoveX = 0f;            
        }
    }
}
