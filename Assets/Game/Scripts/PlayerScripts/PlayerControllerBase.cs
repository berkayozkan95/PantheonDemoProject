using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected CharacterController playerController;
    [SerializeField] protected float characterSpeed;

    [Header("Animation")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected float delayTimerOnStop;
    protected Vector3 startPosition;
    protected bool isMoving => characterSpeed > 0;

    public float DistanceToFinish{
        get{
            float distance = GameManager.Instance.finishLine.transform.position.x - this.transform.position.x;
            return distance;
        }
    }

    protected virtual void Start() {
        startPosition = gameObject.transform.position;
    }

    protected virtual void Update()
    { 
        anim.SetBool("isMoving", isMoving);
        if(!isMoving) return;
    }

    public void BackToStart(){
        playerController.enabled = false;
        gameObject.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);     
        playerController.enabled = true;
    }

    public void Stop(){
        characterSpeed = 0;
    }
}
