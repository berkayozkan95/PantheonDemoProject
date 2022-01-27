using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIController : PlayerControllerBase
{    
    [Header("Pathfinding")]

    private Vector3 target;
    public Collider FinishLine;
    private Path path;
    private int currentWayPoint = 0;
    private bool reachedEndOfPath = false;
    private float nextWayPointDistance = 5f;
    private Seeker seeker;
    private Rigidbody rb;

    protected override void Start()
    {   
        base.Start();
        rb = GetComponent<Rigidbody>();
        seeker = GetComponent<Seeker>();
        playerController = GetComponent<CharacterController>();
        target = FinishLine.bounds.ClosestPoint(rb.transform.position);

        InvokeRepeating("UpdatePath", 0, 0.4f);
    }

    private void UpdatePath(){
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target, OnPathComplete);
    }

    private void OnPathComplete(Path p){

        if(!p.error){
            path = p;
            currentWayPoint = 0;
        }
    }

    protected override void Update()
    {
             
        base.Update();
        if(!isMoving) return;
        if(path == null) return;
        if(currentWayPoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            characterSpeed = 0;
            return;
        }
        else
            reachedEndOfPath = false;

        Vector3 direction =  new Vector3(path.vectorPath[currentWayPoint].x- rb.position.x, 0 ,path.vectorPath[currentWayPoint].z- rb.position.z).normalized;

        playerController.Move(direction * Time.deltaTime * characterSpeed);

        float distance = Vector3.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if(distance < nextWayPointDistance) currentWayPoint ++;


    }
}
