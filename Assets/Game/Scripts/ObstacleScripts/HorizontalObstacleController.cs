using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    RightLeft = 0,
    ForwardBack = 1,
}

public class HorizontalObstacleController : ObstacleBase
{
    [Header("Properties")]
    [SerializeField] private Direction moveDirection;
    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeToWait;
    
    private Vector3 startPos;
    private Vector3 targetPosition;
    private Vector3 currentTarget;
    private Vector3 movementVector;
    private Coroutine moveRoutine;


    private void Start() {
        startPos = transform.position;
        movementVector = (Vector3.right * ((int)moveDirection) + Vector3.forward * (1 - (int)moveDirection)) * moveDistance;
        targetPosition = transform.position + movementVector;   
        currentTarget = targetPosition;   
        moveRoutine = StartCoroutine(Move());
    }

    private void SwitchTarget(){
        if(currentTarget == targetPosition)
            currentTarget = startPos;
        else
            currentTarget = targetPosition;
    }
  
    IEnumerator Move(){
        while(true){
            float _step = Time.deltaTime * moveSpeed;
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, _step);
            if (Vector3.Distance(transform.position, currentTarget) < 0.5 )
            {
                yield return new WaitForSeconds(timeToWait);
                SwitchTarget();             
            }
            yield return null;
        }
    }
}
