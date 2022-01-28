using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float characterSpeed;

    [Header("Animation")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected float delayTimerOnStop;
    protected Vector3 startPosition;

    protected bool isMoving{ 
        get
        { 
        if(HasFinished) 
            return false;
        else{
            return true;           
            }
        }
    }
    [SerializeField]protected bool hasFinished = false;

    public bool HasFinished{
        get{ return hasFinished;}
        set{ hasFinished = value;}
    }
    public float DistanceToFinish{
        get{
            float distance = GameManager.Instance.finishLine.transform.position.x - this.transform.position.x;
            return distance;
        }
    }

    protected virtual void Start() {
        startPosition = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    { 
        anim.SetBool("isMoving", isMoving);
        if(!isMoving) return;
    }

    public void BackToStart(){
        gameObject.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);     
    }

    public void Stop(){
        rb.velocity = Vector3.zero;
        rb.detectCollisions = false; //removing collisions at the end as rigidbody collisions tend to push each other off the finish line.
    }
}
