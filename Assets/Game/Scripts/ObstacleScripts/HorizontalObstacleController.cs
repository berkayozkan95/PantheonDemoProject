using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    RightLeft = 0,
    ForwardBack = 1,
}
public class HorizontalObstacleController : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private Direction moveDirection;
    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeToWait;
    
    private Vector3 startPos;
    private Vector3 targetPosition;
    private Vector3 movementVector;


    private void Start() {
        startPos = transform.position;
        movementVector = (Vector3.right * ((int)moveDirection) + Vector3.forward * (1 - (int)moveDirection)) * moveDistance;
        targetPosition = transform.position + movementVector;
        StartCoroutine("Move");
    }

    IEnumerator Move(){
        while(true){
            float _step = Time.deltaTime * moveSpeed;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _step);
            if ((Vector3.Distance(transform.position, targetPosition) < 0.2 && moveSpeed > 0) ||
                    (Vector3.Distance(transform.position, startPos) < 0.2 && moveSpeed < 0))
            {
                yield return new WaitForSeconds(timeToWait);
                moveSpeed *= -1;
            }
            yield return null;
        }
    }
}
